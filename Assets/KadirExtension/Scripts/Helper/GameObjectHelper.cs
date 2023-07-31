using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KadirExtension
{
    public static class GameObjectHelper
    {

        #region GameObject SetPos

        public static void Set(this GameObject me, Vector3 newPos)
        {
            me.transform.position = newPos;
        }

        public static void SetX(this GameObject me, float newX)
        {
            Vector3 pos = me.transform.position;
            pos.x = newX;
            me.transform.position = pos;
        }
        public static void SetY(this GameObject me, float newY)
        {
            Vector3 pos = me.transform.position;
            pos.y = newY;
            me.transform.position = pos;
        }
        public static void SetZ(this GameObject me, float newZ)
        {
            Vector3 pos = me.transform.position;
            pos.z = newZ;
            me.transform.position = pos;
        }
        #endregion

        #region GameObject SetLocalPos
        public static void SetLocalPos(this GameObject me, Vector3 newPos)
        {
            me.transform.localPosition = newPos;
        }
        public static void SetLocalPosX(this GameObject me, float newX)
        {
            me.transform.localPosition = new Vector3(newX, me.transform.localPosition.y, me.transform.localPosition.z);
        }
        public static void SetLocalPosY(this GameObject me, float newY)
        {
            me.transform.localPosition = new Vector3(me.transform.localPosition.x, newY, me.transform.localPosition.z);
        }
        public static void SetLocalPosZ(this GameObject me, float newZ)
        {
            me.transform.localPosition = new Vector3(me.transform.localPosition.x, me.transform.localPosition.y, newZ);
        }
        #endregion

        #region GameObject SetAngle
        public static void SetSetAngle(this GameObject me, Vector3 newRot)
        {
            me.transform.eulerAngles = newRot;
        }

        public static void SetAngleX(this GameObject me, float newX)
        {
            Vector3 newRot = me.transform.eulerAngles;
            newRot.x = newX;
            me.transform.eulerAngles = newRot;
        }
        public static void SetAngleY(this GameObject me, float newY)
        {
            Vector3 newRot = me.transform.eulerAngles;
            newRot.y = newY;
            me.transform.eulerAngles = newRot;
        }
        public static void SetAngleZ(this GameObject me, float newZ)
        {
            Vector3 newRot = me.transform.eulerAngles;
            newRot.z = newZ;
            me.transform.eulerAngles = newRot;
        }
        #endregion

        #region GameObject SetLocalAngle
        public static void SetLocalAngle(this GameObject me, Vector3 newRot)
        {
            me.transform.localEulerAngles = newRot;
        }
        public static void SetLocalAngleX(this GameObject me, float newX)
        {
            me.transform.localEulerAngles = new Vector3(newX, me.transform.localEulerAngles.y, me.transform.localEulerAngles.z);
        }
        public static void SetLocalAngleY(this GameObject me, float newY)
        {
            me.transform.localEulerAngles = new Vector3(me.transform.localEulerAngles.x, newY, me.transform.localEulerAngles.z);
        }
        public static void SetLocalAngleZ(this GameObject me, float newZ)
        {
            me.transform.localEulerAngles = new Vector3(me.transform.localEulerAngles.x, me.transform.localEulerAngles.y, newZ);
        }
        #endregion

        #region GameObject AddPosition

        public static void Add(this GameObject me, Vector3 newPos)
        {
            me.transform.position += newPos;
        }

        public static void AddX(this GameObject me, float newX)
        {
            Vector3 pos = me.transform.position;
            pos.x += newX;
            me.transform.position = pos;
        }
        public static void AddY(this GameObject me, float newY)
        {
            Vector3 pos = me.transform.position;
            pos.y += newY;
            me.transform.position = pos;
        }
        public static void AddZ(this GameObject me, float newZ)
        {
            Vector3 pos = me.transform.position;
            pos.z += newZ;
            me.transform.position = pos;
        }
        #endregion

        #region GameObject AddLocalPosition

        public static void AddLocalPos(this GameObject me, Vector3 newPos)
        {
            me.transform.position += newPos;
        }

        public static void AddLocalPosX(this GameObject me, float newX)
        {
            Vector3 pos = me.transform.localPosition;
            pos.x += newX;
            me.transform.localPosition = pos;
        }
        public static void AddLocalPosY(this GameObject me, float newY)
        {
            Vector3 pos = me.transform.localPosition;
            pos.y += newY;
            me.transform.localPosition = pos;
        }
        public static void AddLocalPosZ(this GameObject me, float newZ)
        {
            Vector3 pos = me.transform.localPosition;
            pos.z += newZ;
            me.transform.localPosition = pos;
        }
        #endregion

        #region GetChild Extension GameObject

        public static GameObject GetChildWithIndex(this GameObject me, int index)
        {
            return me.transform.GetChild(index).gameObject;
        }
        public static GameObject GetFirstChild(this GameObject me, int index)
        {
            return me.transform.GetChild(0).gameObject;
        }

        public static GameObject GetLastChild(GameObject me, int index)
        {
            return me.transform.GetChild(me.transform.childCount - 1).gameObject;
        }

        #endregion

    }
}