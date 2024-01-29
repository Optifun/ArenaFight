using ME.ECS;
using Scripts.Arena.Components;
using Scripts.Arena.Features.Components;
using UnityEngine;

namespace Scripts.Arena.Features
{
    using Input.Components;
    using Input.Modules;
    using Input.Systems;
    using Input.Markers;

    namespace Input.Components
    {
    }

    namespace Input.Modules
    {
    }

    namespace Input.Systems
    {
    }

    namespace Input.Markers
    {
    }

#if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
#endif
    public sealed class InputFeature : Feature
    {
        private Filter _inputFilter;

        protected override void OnConstruct()
        {
            AddModule<InputModule>();
            Filter.Create("Filter-Input").With<PlayerId>().With<InputComponent>().Push(ref _inputFilter);
        }

        protected override void OnConstructLate()
        {
            ref var input = ref world.AddEntity();
            input
                .Set(new InputComponent() {Value = Vector2.zero})
                .Set(new PlayerId() {Id = 0});
        }
        
        protected override void OnDeconstruct()
        {
        }

        public Entity GetInput(int playerId)
        {
            foreach (Entity entity in _inputFilter)
            {
                if (entity.Read<PlayerId>().Id == playerId)
                {
                    return entity;
                }
            }
            Debug.LogWarning("you are trying to find entity that does not exist");
            return Entity.Empty;
        }
    }
}