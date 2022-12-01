using System;
using Game;
using Stateless;

namespace Infrastructure.Services.Game
{
    public class GameStateMachine : StateMachine<GameState, GameEvent>
    {
        private readonly StateMachine<GameState, GameEvent> _stateMachine =
            new StateMachine<GameState, GameEvent>(GameState.Loading, FiringMode.Queued);

        private TriggerWithParameters<ArenaResult> _finishArenaTrigger;

        public GameStateMachine(Func<GameState> stateAccessor, Action<GameState> stateMutator)
            : base(stateAccessor, stateMutator)
        {
            ConfigureStates();
        }

        public GameStateMachine(GameState initialState) : base(initialState)
        {
            ConfigureStates();
        }

        public GameStateMachine(Func<GameState> stateAccessor, Action<GameState> stateMutator, FiringMode firingMode)
            : base(stateAccessor, stateMutator, firingMode)
        {
            ConfigureStates();
        }

        public GameStateMachine(GameState initialState, FiringMode firingMode) : base(initialState, firingMode)
        {
            ConfigureStates();
        }

        public void FinishArena(ArenaResult result) =>
            _stateMachine.Fire(_finishArenaTrigger, result);

        private void ConfigureStates()
        {
            _finishArenaTrigger = _stateMachine.SetTriggerParameters<ArenaResult>(GameEvent.FinishArena);
            
            _stateMachine.Configure(GameState.Loading)
                .Permit(GameEvent.ResourcesLoaded, GameState.MainMenu);

            _stateMachine.Configure(GameState.MainMenu)
                .Permit(GameEvent.EnterArena, GameState.Arena)
                .OnEntryFrom(_finishArenaTrigger, result => { });

            _stateMachine.Configure(GameState.Arena)
                .Permit(GameEvent.FinishArena, GameState.MainMenu);
        }
    }
}