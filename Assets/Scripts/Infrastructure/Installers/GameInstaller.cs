using Cysharp.Threading.Tasks;
using Infrastructure.Services.Game;
using Zenject;

namespace Infrastructure.Installers
{
    public class GameInstaller : MonoInstaller, IInitializable
    {
        public override void InstallBindings()
        {
            Container.Bind<GameStateMachine>().To<GameStateMachine>().AsSingle();
            Container.Bind<IInitializable>().To<GameInstaller>().FromInstance(this);
        }

        public void Initialize()
        {
            var gameStateMachine = Container.Resolve<GameStateMachine>();
            gameStateMachine.ActivateAsync().Forget();
        }
    }
}