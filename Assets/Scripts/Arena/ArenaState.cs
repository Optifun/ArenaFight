using System;
using Arena.Services;
using UnityEngine;

namespace Scripts.Arena
{
    public class ArenaState : ME.ECS.State
    {
        public IInputService InputService => _inputService.Value;
        private readonly Lazy<IInputService> _inputService = new(NewInputService);

        private static IInputService NewInputService()
        {
            var go = new GameObject();
            return go.AddComponent<KeyboardInputService>();
        }
    }
}