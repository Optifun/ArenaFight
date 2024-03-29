﻿using Arena.Physics.Systems;
using ME.ECS;

namespace Arena.Physics {
    #if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
    #endif
    public sealed class PhysicsFeature : Feature {

        protected override void OnConstruct()
        {
            this.AddSystem<ApplySpeedSystem>();
        }

        protected override void OnDeconstruct() {
            
        }

    }

}