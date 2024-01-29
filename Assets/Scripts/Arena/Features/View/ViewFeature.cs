using ME.ECS;
using Scripts.Arena.Systems;

namespace Scripts.Arena.Features {

    #if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
    #endif
    public sealed class ViewFeature : Feature {

        protected override void OnConstruct()
        {
            AddSystem<SyncUnityTransformSystem>();
        }

        protected override void OnDeconstruct() {
            
        }

    }

}