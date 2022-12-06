using Cysharp.Threading.Tasks;
using Infrastructure.Services.Game;

namespace Infrastructure.Core
{
    public interface IStateMachine<TState, TTrigger>
    {
        UniTask ActivateAsync();
        void Activate();
        void Fire(TTrigger trigger);
        UniTask FireAsync(TTrigger trigger);
    }
}