using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace KadirExtension
{
    public static class VectorHelper
    {
        #region Vector3 SetPosition
        public static Vector3 Set(this Vector3 me, Vector3 newPos)
        {
            return newPos;
        }
        public static Vector3 SetX(this Vector3 me, float newX)
        {
            me.x = newX;
            return me;
        }
        public static Vector3 SetY(this Vector3 me, float newY)
        {
            me.y = newY;
            return me;
        }
        public static Vector3 SetZ(this Vector3 me, float newZ)
        {
            me.z = newZ;
            return me;
        }
        #endregion

        #region Vector3 AddPosition
        public static Vector3 Add(this Vector3 me, Vector3 newPos)
        {
            return me + newPos;
        }
        public static Vector3 AddX(this Vector3 me, float newX)
        {
            me.x += newX;
            return me;
        }
        public static Vector3 AddY(this Vector3 me, float newY)
        {
            me.y += newY;
            return me;
        }
        public static Vector3 CAddZ(this Vector3 me, float newZ)
        {
            me.z += newZ;
            return me;
        }
        #endregion

        #region Vector2 SetPosition
        public static Vector2 Set(this ref Vector2 me, Vector2 newPos)
        {
            return newPos;
        }
        public static Vector2 SetX(this ref Vector2 me, float newX)
        {
            me.x = newX;
            return me;
        }
        public static Vector2 SetY(this ref Vector2 me, float newY)
        {
            me.y = newY;
            return me;
        }

        #endregion

        #region Vector2 AddPosition
        public static Vector2 Add(this ref Vector2 me, Vector2 newPos)
        {
            return me + newPos;
        }
        public static Vector2 AddX(this ref Vector2 me, float newX)
        {
            me.x += newX;
            return me;
        }
        public static Vector2 AddY(this ref Vector2 me, float newY)
        {
            me.y += newY;
            return me;
        }

        #endregion

    }
}
