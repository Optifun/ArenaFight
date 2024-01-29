using UnityEngine;

namespace Arena.Utils
{
    public static class PositionExtensions
    {
        public static Vector2 XY(this Vector3 vector3) => new Vector2(vector3.x, vector3.y);
        public static Vector2 XZ(this Vector3 vector3) => new Vector2(vector3.x, vector3.z);
        public static Vector2 YZ(this Vector3 vector3) => new Vector2(vector3.y, vector3.z);

        public static Vector3 AsXY0(this Vector2 vector2) => vector2;
        public static Vector3 AsX0Z(this Vector2 vector2) => new Vector3(vector2.x, 0, vector2.y);
        public static Vector3 As0YZ(this Vector2 vector2) => new Vector3(0, vector2.x, vector2.y);
    }
}