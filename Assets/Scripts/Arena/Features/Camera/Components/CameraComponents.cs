using Arena.StaticData;
using ME.ECS;

namespace Scripts.Arena.Features.Components
{
    public struct CameraTag : IStructComponent
    {
    }

    public struct CameraTargetTag : IStructComponent
    {
    }

    public struct CameraComponent : IComponent
    {
        public UnityEngine.Camera Camera;
    }

    public struct CameraConfigComponent : IComponent
    {
        public CameraConfig Value;
    }
}