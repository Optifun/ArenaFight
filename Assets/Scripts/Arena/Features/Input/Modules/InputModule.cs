using Arena.Input.Components;
using Arena.Services;
using ME.ECS;

namespace Arena.Input.Modules {
#if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
    #endif
    public sealed class InputModule : IModule, IUpdate {
        
        private InputFeature _feature;
        private IInputService _inputService;

        public World world { get; set; }

        void IModuleBase.OnConstruct()
        {
            _feature = world.GetFeature<InputFeature>();
        }

        void IModuleBase.OnDeconstruct() {}

        void IUpdate.Update(in float deltaTime)
        {
            _inputService = world.GetState<ArenaState>().InputService;
            Entity inputEntity = _feature.GetInput(0);
            if (inputEntity.IsEmpty())
            {
                return;
            }
            inputEntity.Set(new InputComponent() {Value = _inputService.Axis});
        }


    }
    
}
