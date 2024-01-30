using Arena.Camera.Components;
using Arena.Camera.Systems;
using Arena.Components;
using Arena.Physics.Components;
using Arena.StaticData;
using ME.ECS;
using UnityEngine;

namespace Arena.Camera
{
#if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
#endif
    public sealed class CameraFeature : Feature, ISystemConstructLate
    {
        [SerializeField] private CameraConfig _config;

        protected override void OnConstruct()
        {
            AddSystem<InitCameraSystem>();
            AddSystem<CameraFollowTargetSystem>();
            AddSystem<ZoomCameraSystem>();
        }

        protected override void OnDeconstruct()
        {
        }

        public Entity CreateCameraEntity(Vector3 position)
        {
            var go = Object.Instantiate(_config.Prefab, position, Quaternion.identity);
            var camera = go.GetComponentInChildren<UnityEngine.Camera>();
            ref var entity = ref world.AddEntity();

            entity.Set(new CameraTag())
               .Set(new CameraConfigComponent() {Value = _config})
               .Set(new PositionComponent())
               .Set(new SpeedComponent {MaximumSpeed = _config.MaximumSpeed})
               .Set(new CameraComponent() {Camera = camera})
               .Set(new UnityTransform() {Value = go.transform});

            return entity;
        }

        public void OnConstructLate()
        {
            CreateCameraEntity(Vector3.back*100);
        }
    }
}