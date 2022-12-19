using System.Runtime.CompilerServices;
using Leopotam.Ecs;
using Zenject;

namespace Extensions
{
    public static class SystemsExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static EcsSystems AddResolved<TSystem>(this EcsSystems ecsSystems, DiContainer diContainer)
            where TSystem : IEcsSystem =>
            ecsSystems.Add(diContainer.Resolve<TSystem>());
    }
}