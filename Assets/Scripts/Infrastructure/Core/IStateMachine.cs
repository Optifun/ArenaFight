using Cysharp.Threading.Tasks;
using Infrastructure.Services.Game;

namespace Infrastructure.Core
{
    public interface IStateMachine
    {
        UniTask ActivateAsync();
        void Activate();
        void Fire(GameEvent trigger);
        UniTask FireAsync(GameEvent trigger);
    }
}