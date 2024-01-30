using Arena.StaticData;
using ME.ECS;

namespace Arena.Camera.Components
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