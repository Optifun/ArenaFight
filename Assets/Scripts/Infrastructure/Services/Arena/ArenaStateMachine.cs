using Cysharp.Threading.Tasks;
using Infrastructure.Core;
using Stateless;
using StaticData;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Infrastructure.Services.Arena
{
    public class ArenaStateMachine : IStateMachine<ArenaState, ArenaEvent>
    {
        private readonly StateMachine<ArenaState, ArenaEvent> _stateMachine =
            new StateMachine<ArenaState, ArenaEvent>(ArenaState.Initial, FiringMode.Queued);

        private readonly ArenaInfo _arenaInfo;
        private SceneContext _sceneContext;

        public ArenaStateMachine(ArenaInfo arenaInfo)
        {
            _arenaInfo = arenaInfo;
            ConfigureStates();
        }

        public UniTask ActivateAsync() =>
            _stateMachine.ActivateAsync().AsUniTask();

        public void Activate() =>
            _stateMachine.Activate();

        public void Fire(ArenaEvent trigger) =>
            _stateMachine.Fire(trigger);

        public UniTask FireAsync(ArenaEvent trigger) =>
            _stateMachine.FireAsync(trigger).AsUniTask();

        private void ConfigureStates()
        {
            _stateMachine.Configure(ArenaState.Initial)
                .Permit(ArenaEvent.LoadResources, ArenaState.LoadingMap)
                .OnActivate(() => _stateMachine.FireAsync(ArenaEvent.LoadResources));

            _stateMachine.Configure(ArenaState.LoadingMap)
                .Permit(ArenaEvent.SetupSystems, ArenaState.BuildingWorld)
                .OnEntry(() => LoadLevelAsync().Forget());

            _stateMachine.Configure(ArenaState.BuildingWorld)
                .Permit(ArenaEvent.ArenaBuilt, ArenaState.GameLoop)
                .OnEntry(BuildWorld);

            _stateMachine.Configure(ArenaState.Paused)
                .Permit(ArenaEvent.Play, ArenaState.GameLoop)
                .OnEntry(() => _stateMachine.Fire(ArenaEvent.Play));

            _stateMachine.Configure(ArenaState.GameLoop)
                .Permit(ArenaEvent.Pause, ArenaState.Paused)
                .Permit(ArenaEvent.PlayerDead, ArenaState.Wasted)
                .Permit(ArenaEvent.PlayerExited, ArenaState.Exit)
                .OnEntryFrom(ArenaEvent.ArenaBuilt, () => _stateMachine.Fire(ArenaEvent.Pause));

            _stateMachine.OnUnhandledTrigger((state, unhandled) =>
                Debug.Log($"Unhandled event type {unhandled} from state {state}"));
        }

        private async UniTask LoadLevelAsync()
        {
            await SceneManager.LoadSceneAsync(_arenaInfo.Scene.name, LoadSceneMode.Additive)
                .ToUniTask();

            var levelScene = SceneManager.GetSceneByName(_arenaInfo.Scene.name);
            SceneManager.SetActiveScene(levelScene);
            Debug.Log("Level scene loaded");

            _stateMachine.Fire(ArenaEvent.SetupSystems);
        }

        private void BuildWorld()
        {
            Debug.Log("Building arena");
            var gameObject = GameObject.Find(Globals.LevelInstallerGO);
            _sceneContext = gameObject.GetComponent<SceneContext>();
            _sceneContext.Run();

            Debug.Log("Arena was built");
            _stateMachine.Fire(ArenaEvent.ArenaBuilt);
        }
    }
}