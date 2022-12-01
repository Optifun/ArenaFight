using System;
using Cysharp.Threading.Tasks;
using Game;
using Infrastructure.Core;
using Infrastructure.Services.Arena;
using Stateless;
using StaticData;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.Services.Game
{
    public class GameStateMachine : IStateMachine<GameState, GameEvent>
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
                .OnActivate(() => PlayLevel(ScriptableObject.CreateInstance<ArenaInfo>()))
                .OnEntryFrom(_finishArenaTrigger, result => { });

            _stateMachine.Configure(GameState.Arena)
                .Permit(GameEvent.FinishArena, GameState.MainMenu);
        }

        private void PlayLevel(ArenaInfo arenaInfo)
        {
            ArenaStateMachine arenaStateMachine = new ArenaStateMachine(arenaInfo);
            arenaStateMachine.Activate();
        }

        public UniTask ActivateAsync() =>
            _stateMachine.ActivateAsync().AsUniTask();

        public void Activate() =>
            _stateMachine.Activate();

        public void Fire(GameEvent trigger) =>
            _stateMachine.Fire(trigger);

        public UniTask FireAsync(GameEvent trigger) =>
            _stateMachine.FireAsync(trigger).AsUniTask();

        public void FinishArena(ArenaResult result) =>
            _stateMachine.Fire(_finishArenaTrigger, result);

        private async UniTask LoadGameAsync()
        {
            // TODO: warmup resources or something
            await SceneManager.LoadSceneAsync(Globals.GameScene, LoadSceneMode.Additive).ToUniTask();
            Debug.Log("Game is loading...");
            await FireAsync(GameEvent.ResourcesLoaded);
        }
    }
}