using UnityEngine;

namespace Arena.Services
{
    public class KeyboardInputService : MonoBehaviour, IInputService
    {
        public Vector2 Axis { get; private set; }

        private void FixedUpdate()
        {
            Axis = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            Axis = Vector2.ClampMagnitude(Axis, 1);
        }
    }
}