namespace Game.Shared.Components
{
    public struct UnityObject<T> where T : UnityEngine.Object
    {
        public T Value;

        public UnityObject(T value) =>
            Value = value;
    }
}