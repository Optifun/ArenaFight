namespace ME.ECS {

    public static partial class ComponentsInitializer {

        static partial void InitTypeIdPartial() {

            WorldUtilities.ResetTypeIds();

            CoreComponentsInitializer.InitTypeId();


            WorldUtilities.InitComponentTypeId<Arena.Character.Components.ExperienceComponent>(false, true, true, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Arena.Character.Components.HealthComponent>(false, true, true, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Arena.Components.PlayerId>(false, true, true, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Arena.Input.Components.InputComponent>(false, true, true, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Arena.Physics.Components.PositionComponent>(false, true, true, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Arena.Physics.Components.RotationComponent>(false, true, true, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Arena.Physics.Components.SpeedComponent>(false, true, true, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Arena.Camera.Components.CameraTag>(true, true, true, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Arena.Camera.Components.CameraTargetTag>(true, true, true, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Arena.Character.Components.CharacterTag>(true, true, true, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Arena.Events.Components.EventTag>(true, true, true, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Arena.Events.Components.TriggerEventComponent>(false, false, false, false, false, false, false, false, true, false);
            WorldUtilities.InitComponentTypeId<Arena.Camera.Components.CameraComponent>(false, true, false, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Arena.Camera.Components.CameraConfigComponent>(false, true, false, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Arena.Components.UnityTransform>(false, true, false, false, false, false, false, false, false, false);

        }

        static partial void Init(State state, ref ME.ECS.World.NoState noState) {

            WorldUtilities.ResetTypeIds();

            CoreComponentsInitializer.InitTypeId();


            WorldUtilities.InitComponentTypeId<Arena.Character.Components.ExperienceComponent>(false, true, true, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Arena.Character.Components.HealthComponent>(false, true, true, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Arena.Components.PlayerId>(false, true, true, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Arena.Input.Components.InputComponent>(false, true, true, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Arena.Physics.Components.PositionComponent>(false, true, true, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Arena.Physics.Components.RotationComponent>(false, true, true, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Arena.Physics.Components.SpeedComponent>(false, true, true, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Arena.Camera.Components.CameraTag>(true, true, true, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Arena.Camera.Components.CameraTargetTag>(true, true, true, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Arena.Character.Components.CharacterTag>(true, true, true, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Arena.Events.Components.EventTag>(true, true, true, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Arena.Events.Components.TriggerEventComponent>(false, false, false, false, false, false, false, false, true, false);
            WorldUtilities.InitComponentTypeId<Arena.Camera.Components.CameraComponent>(false, true, false, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Arena.Camera.Components.CameraConfigComponent>(false, true, false, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Arena.Components.UnityTransform>(false, true, false, false, false, false, false, false, false, false);

            ComponentsInitializerWorld.Setup(ComponentsInitializerWorldGen.Init);
            CoreComponentsInitializer.Init(state, ref noState);


            state.structComponents.ValidateUnmanaged<Arena.Character.Components.ExperienceComponent>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Arena.Character.Components.HealthComponent>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Arena.Components.PlayerId>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Arena.Input.Components.InputComponent>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Arena.Physics.Components.PositionComponent>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Arena.Physics.Components.RotationComponent>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Arena.Physics.Components.SpeedComponent>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Arena.Camera.Components.CameraTag>(ref state.allocator, true);
            state.structComponents.ValidateUnmanaged<Arena.Camera.Components.CameraTargetTag>(ref state.allocator, true);
            state.structComponents.ValidateUnmanaged<Arena.Character.Components.CharacterTag>(ref state.allocator, true);
            state.structComponents.ValidateUnmanaged<Arena.Events.Components.EventTag>(ref state.allocator, true);
            noState.storage.ValidateOneShot<Arena.Events.Components.TriggerEventComponent>(false);
            state.structComponents.Validate<Arena.Camera.Components.CameraComponent>(false);
            state.structComponents.Validate<Arena.Camera.Components.CameraConfigComponent>(false);
            state.structComponents.Validate<Arena.Components.UnityTransform>(false);

        }

    }

    public static class ComponentsInitializerWorldGen {

        public static void Init(Entity entity) {


            entity.ValidateDataUnmanaged<Arena.Character.Components.ExperienceComponent>(false);
            entity.ValidateDataUnmanaged<Arena.Character.Components.HealthComponent>(false);
            entity.ValidateDataUnmanaged<Arena.Components.PlayerId>(false);
            entity.ValidateDataUnmanaged<Arena.Input.Components.InputComponent>(false);
            entity.ValidateDataUnmanaged<Arena.Physics.Components.PositionComponent>(false);
            entity.ValidateDataUnmanaged<Arena.Physics.Components.RotationComponent>(false);
            entity.ValidateDataUnmanaged<Arena.Physics.Components.SpeedComponent>(false);
            entity.ValidateDataUnmanaged<Arena.Camera.Components.CameraTag>(true);
            entity.ValidateDataUnmanaged<Arena.Camera.Components.CameraTargetTag>(true);
            entity.ValidateDataUnmanaged<Arena.Character.Components.CharacterTag>(true);
            entity.ValidateDataUnmanaged<Arena.Events.Components.EventTag>(true);
            entity.ValidateDataOneShot<Arena.Events.Components.TriggerEventComponent>(false);
            entity.ValidateData<Arena.Camera.Components.CameraComponent>(false);
            entity.ValidateData<Arena.Camera.Components.CameraConfigComponent>(false);
            entity.ValidateData<Arena.Components.UnityTransform>(false);

        }

    }

}
