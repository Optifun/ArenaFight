using System;
using UnityEngine;

namespace Game.Shared.Services
{
    public interface IInputService
    {
        Vector2 Axis { get; }
    }
}