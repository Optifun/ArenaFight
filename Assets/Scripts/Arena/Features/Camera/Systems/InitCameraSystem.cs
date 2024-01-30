using ME.ECS;
using UnityEngine;

namespace Arena.Camera.Systems
{
#if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
#endif
    public sealed class InitCameraSystem : ISystemBase, ISystemConstructLate
    {
        private CameraFeature feature;

        public World world { get; set; }

        void ISystemBase.OnConstruct()
        {
            feature = world.GetFeature<CameraFeature>();
        }

        void ISystemBase.OnDeconstruct()
        {
        }

        public void OnConstructLate()
        {
            feature.CreateCameraEntity(Vector3.zero);
        }
    }
}