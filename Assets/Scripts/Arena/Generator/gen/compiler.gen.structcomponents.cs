namespace ME.ECS {

    public static partial class ComponentsInitializer {

        static partial void InitTypeIdPartial() {

            WorldUtilities.ResetTypeIds();

            CoreComponentsInitializer.InitTypeId();


            WorldUtilities.InitComponentTypeId<Scripts.Arena.Components.PlayerId>(false, true, true, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Scripts.Arena.Features.Components.ExperienceComponent>(false, true, true, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Scripts.Arena.Features.Components.HealthComponent>(false, true, true, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Scripts.Arena.Features.Components.InputComponent>(false, true, true, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Scripts.Arena.Features.Components.PositionComponent>(false, true, true, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Scripts.Arena.Features.Components.RotationComponent>(false, true, true, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Scripts.Arena.Features.Components.SpeedComponent>(false, true, true, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Game.Features.Tags.EventTag>(true, true, true, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Scripts.Arena.Features.Components.CameraTag>(true, true, true, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Scripts.Arena.Features.Components.CameraTargetTag>(true, true, true, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Scripts.Arena.Features.Components.CharacterTag>(true, true, true, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Game.Features.Events.TriggerEventComponent>(false, false, false, false, false, false, false, false, true, false);
            WorldUtilities.InitComponentTypeId<Scripts.Arena.Components.UnityTransform>(false, true, false, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Scripts.Arena.Features.Components.CameraComponent>(false, true, false, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Scripts.Arena.Features.Components.CameraConfigComponent>(false, true, false, false, false, false, false, false, false, false);

        }

        static partial void Init(State state, ref ME.ECS.World.NoState noState) {

            WorldUtilities.ResetTypeIds();

            CoreComponentsInitializer.InitTypeId();


            WorldUtilities.InitComponentTypeId<Scripts.Arena.Components.PlayerId>(false, true, true, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Scripts.Arena.Features.Components.ExperienceComponent>(false, true, true, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Scripts.Arena.Features.Components.HealthComponent>(false, true, true, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Scripts.Arena.Features.Components.InputComponent>(false, true, true, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Scripts.Arena.Features.Components.PositionComponent>(false, true, true, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Scripts.Arena.Features.Components.RotationComponent>(false, true, true, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Scripts.Arena.Features.Components.SpeedComponent>(false, true, true, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Game.Features.Tags.EventTag>(true, true, true, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Scripts.Arena.Features.Components.CameraTag>(true, true, true, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Scripts.Arena.Features.Components.CameraTargetTag>(true, true, true, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Scripts.Arena.Features.Components.CharacterTag>(true, true, true, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Game.Features.Events.TriggerEventComponent>(false, false, false, false, false, false, false, false, true, false);
            WorldUtilities.InitComponentTypeId<Scripts.Arena.Components.UnityTransform>(false, true, false, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Scripts.Arena.Features.Components.CameraComponent>(false, true, false, false, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Scripts.Arena.Features.Components.CameraConfigComponent>(false, true, false, false, false, false, false, false, false, false);

            ComponentsInitializerWorld.Setup(ComponentsInitializerWorldGen.Init);
            CoreComponentsInitializer.Init(state, ref noState);


            state.structComponents.ValidateUnmanaged<Scripts.Arena.Components.PlayerId>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Scripts.Arena.Features.Components.ExperienceComponent>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Scripts.Arena.Features.Components.HealthComponent>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Scripts.Arena.Features.Components.InputComponent>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Scripts.Arena.Features.Components.PositionComponent>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Scripts.Arena.Features.Components.RotationComponent>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Scripts.Arena.Features.Components.SpeedComponent>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Game.Features.Tags.EventTag>(ref state.allocator, true);
            state.structComponents.ValidateUnmanaged<Scripts.Arena.Features.Components.CameraTag>(ref state.allocator, true);
            state.structComponents.ValidateUnmanaged<Scripts.Arena.Features.Components.CameraTargetTag>(ref state.allocator, true);
            state.structComponents.ValidateUnmanaged<Scripts.Arena.Features.Components.CharacterTag>(ref state.allocator, true);
            noState.storage.ValidateOneShot<Game.Features.Events.TriggerEventComponent>(false);
            state.structComponents.Validate<Scripts.Arena.Components.UnityTransform>(false);
            state.structComponents.Validate<Scripts.Arena.Features.Components.CameraComponent>(false);
            state.structComponents.Validate<Scripts.Arena.Features.Components.CameraConfigComponent>(false);

        }

    }

    public static class ComponentsInitializerWorldGen {

        public static void Init(Entity entity) {


            entity.ValidateDataUnmanaged<Scripts.Arena.Components.PlayerId>(false);
            entity.ValidateDataUnmanaged<Scripts.Arena.Features.Components.ExperienceComponent>(false);
            entity.ValidateDataUnmanaged<Scripts.Arena.Features.Components.HealthComponent>(false);
            entity.ValidateDataUnmanaged<Scripts.Arena.Features.Components.InputComponent>(false);
            entity.ValidateDataUnmanaged<Scripts.Arena.Features.Components.PositionComponent>(false);
            entity.ValidateDataUnmanaged<Scripts.Arena.Features.Components.RotationComponent>(false);
            entity.ValidateDataUnmanaged<Scripts.Arena.Features.Components.SpeedComponent>(false);
            entity.ValidateDataUnmanaged<Game.Features.Tags.EventTag>(true);
            entity.ValidateDataUnmanaged<Scripts.Arena.Features.Components.CameraTag>(true);
            entity.ValidateDataUnmanaged<Scripts.Arena.Features.Components.CameraTargetTag>(true);
            entity.ValidateDataUnmanaged<Scripts.Arena.Features.Components.CharacterTag>(true);
            entity.ValidateDataOneShot<Game.Features.Events.TriggerEventComponent>(false);
            entity.ValidateData<Scripts.Arena.Components.UnityTransform>(false);
            entity.ValidateData<Scripts.Arena.Features.Components.CameraComponent>(false);
            entity.ValidateData<Scripts.Arena.Features.Components.CameraConfigComponent>(false);

        }

    }

}
