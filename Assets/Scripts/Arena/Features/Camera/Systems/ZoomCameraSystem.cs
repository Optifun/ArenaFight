using Arena.Camera.Components;
using Arena.StaticData;
using ME.ECS;
using UnityEngine;

namespace Arena.Camera.Systems
{

#if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
#endif
    public sealed class ZoomCameraSystem : ISystemFilter
    {
        private CameraFeature feature;

        public World world { get; set; }

        void ISystemBase.OnConstruct()
        {
            this.GetFeature(out this.feature);
        }

        void ISystemBase.OnDeconstruct()
        {
        }

#if !CSHARP_8_OR_NEWER
        bool ISystemFilter.jobs => false;
        int ISystemFilter.jobsBatchCount => 64;
#endif
        Filter ISystemFilter.filter { get; set; }

        Filter ISystemFilter.CreateFilter()
        {
            return Filter.Create("Filter-ZoomCameraSystem").With<CameraTag>().Push();
        }

        void ISystemFilter.AdvanceTick(in Entity entity, in float deltaTime)
        {
            ref readonly var cameraConfig = ref entity.Read<CameraConfigComponent>();
            ref readonly var camera = ref entity.Read<CameraComponent>();
            CorrectPosition(camera, cameraConfig.Value);
        }

        private void CorrectPosition(CameraComponent camera, CameraConfig config)
        {
            var angle = 90 - config.CameraAngle;
            var verticalOffset = Mathf.Pow(2, config.Zoom);
            var horizontalOffset = verticalOffset * Mathf.Sin(Mathf.Deg2Rad * angle);

            camera.Camera.transform.SetLocalPositionAndRotation(new Vector3(0, verticalOffset, -horizontalOffset), 
                Quaternion.Euler(90 - angle, 0, 0));
        }
    }
}