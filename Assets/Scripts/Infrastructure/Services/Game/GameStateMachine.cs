using System.Threading.Tasks;
using Arena.StaticData;
using Cysharp.Threading.Tasks;
using Game;
using Infrastructure.Core;
using Infrastructure.Services.Arena;
using Stateless;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Infrastructure.Services.Game
{
    public class GameStateMachine : IStateMachine<GameState, GameEvent>
    {
        private readonly StateMachine<GameState, GameEvent> _stateMachine =
            new StateMachine<GameState, GameEvent>(GameState.Loading, FiringMode.Queued);

        private StateMachine<GameState, GameEvent>.TriggerWithParameters<ArenaResult> _finishArenaTrigger;

        public GameStateMachine() =>
            ConfigureStates();

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

        private void ConfigureStates()
        {
            _finishArenaTrigger = _stateMachine.SetTriggerParameters<ArenaResult>(GameEvent.FinishArena);

            _stateMachine.Configure(GameState.Loading)
                .Permit(GameEvent.ResourcesLoaded, GameState.MainMenu)
                .OnActivateAsync(async () => await LoadGameAsync().AsTask());

            _stateMachine.Configure(GameState.MainMenu)
                .Permit(GameEvent.EnterArena, GameState.Arena)
                .OnEntryAsync(async () => await PlayFirstLevel().AsTask())
                .OnEntryFrom(_finishArenaTrigger, result => { });

            _stateMachine.Configure(GameState.Arena)
                .Permit(GameEvent.FinishArena, GameState.MainMenu);

            _stateMachine.OnUnhandledTrigger((state, unhandled) =>
                Debug.Log($"Unhandled event type {unhandled} from state {state}"));
        }

        private async UniTask LoadGameAsync()
        {
            // TODO: warmup resources or something
            await SceneManager.LoadSceneAsync(Globals.GameScene, LoadSceneMode.Additive).ToUniTask();
            Debug.Log("Game is loading...");
            await FireAsync(GameEvent.ResourcesLoaded);
        }

        private async UniTask PlayFirstLevel()
        {
            Debug.Log("Play first level");
            var arenaInfo = await Addressables.LoadAssetAsync<ArenaInfo>("Configs/Level_1").ToUniTask();
            await SceneManager.UnloadSceneAsync(Globals.GameScene).ToUniTask();
            PlayLevel(arenaInfo);
        }

        private void PlayLevel(ArenaInfo arenaInfo)
        {
            ArenaStateMachine arenaStateMachine = new ArenaStateMachine(arenaInfo);
            arenaStateMachine.ActivateAsync();
            Fire(GameEvent.EnterArena);
        }
    }
}