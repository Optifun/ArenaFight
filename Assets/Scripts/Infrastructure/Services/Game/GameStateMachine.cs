using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using DefaultNamespace;
using Game;
using Infrastructure.Core;
using Stateless;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.Services.Game
{
    public class GameStateMachine : IStateMachine
    {
        private readonly StateMachine<GameState, GameEvent> _stateMachine =
            new StateMachine<GameState, GameEvent>(GameState.Loading, FiringMode.Queued);

        private StateMachine<GameState, GameEvent>.TriggerWithParameters<ArenaResult> _finishArenaTrigger;

        public GameStateMachine()
        {
            ConfigureStates();
        }

        private void ConfigureStates()
        {
            _finishArenaTrigger = _stateMachine.SetTriggerParameters<ArenaResult>(GameEvent.FinishArena);

            _stateMachine.Configure(GameState.Loading)
                .OnActivateAsync(async () => await LoadGameAsync())
                .Permit(GameEvent.ResourcesLoaded, GameState.MainMenu);

            _stateMachine.Configure(GameState.MainMenu)
                .Permit(GameEvent.EnterArena, GameState.Arena)
                .OnEntryFrom(_finishArenaTrigger, result => { });

            _stateMachine.Configure(GameState.Arena)
                .Permit(GameEvent.FinishArena, GameState.MainMenu);
        }

        public UniTask ActivateAsync() =>
            _stateMachine.ActivateAsync().AsUniTask();

        public void Activate() =>
            _stateMachine.Activate();

        public void Fire(GameEvent trigger) =>
            _stateMachine.Fire(trigger);

        public UniTask FireAsync(GameEvent trigger) =>
            _stateMachine.FireAsync(trigger).AsUniTask();

        private async UniTask LoadGameAsync()
        {
            // TODO: warmup resources or something
            await SceneManager.LoadSceneAsync(Globals.GameScene, LoadSceneMode.Additive).ToUniTask();
            Debug.Log("Game is loading...");
            await FireAsync(GameEvent.ResourcesLoaded);
            
        }
    }
}