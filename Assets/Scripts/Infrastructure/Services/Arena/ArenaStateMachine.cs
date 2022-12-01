using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Game;
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
                .Permit(ArenaEvent.SetupSystems, ArenaState.BuildingWorld);

            _stateMachine.Configure(ArenaState.BuildingWorld)
                .Permit(ArenaEvent.ArenaBuilt, ArenaState.GameLoop)

            _stateMachine.Configure(ArenaState.Paused)
                .Permit(ArenaEvent.Play, ArenaState.GameLoop)

            _stateMachine.Configure(ArenaState.GameLoop)
                .Permit(ArenaEvent.Pause, ArenaState.Paused)
                .Permit(ArenaEvent.PlayerDead, ArenaState.Wasted)
                .Permit(ArenaEvent.PlayerExited, ArenaState.Exit)
        }

    }
}