using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KadirExtension
{
    public static class TransformHelper
    {
        #region Set Pos

        public static void Set(this Transform me, Vector3 newPos)
        {
            me.position = newPos;
        }
        public static void SetX(this Transform me, float newX)
        {
            Vector3 pos = me.position;
            pos.x = newX;
            me.position = pos;
        }
        public static void SetY(this Transform me, float newY)
        {
            Vector3 pos = me.position;
            pos.y = newY;
            me.position = pos;
        }
        public static void SetZ(this Transform me, float newZ)
        {
            Vector3 pos = me.position;
            pos.z = newZ;
            me.position = pos;
        }
        #endregion

        #region Set LocalPos
        public static void SetLocalPos(this Transform me, Vector3 newPos)
        {
            me.localPosition = newPos;
        }
        public static void SetLocalPosX(this Transform me, float newX)
        {
            me.localPosition = new Vector3(newX, me.localPosition.y, me.localPosition.z);
        }
        public static void SetLocalPosY(this Transform me, float newY)
        {
            me.localPosition = new Vector3(me.localPosition.x, newY, me.localPosition.z);
        }
        public static void SetLocalPosZ(this Transform me, float newZ)
        {
            me.localPosition = new Vector3(me.localPosition.x, me.localPosition.y, newZ);
        }
        #endregion

        #region Set Angle

        public static void SetAngle(this Transform me, Vector3 newRot)
        {
            me.eulerAngles = newRot;
        }
        public static void SetAngleX(this Transform me, float newX)
        {
            Vector3 newRot = me.eulerAngles;
            newRot.x = newX;
            me.eulerAngles = newRot;
        }

        public static void SetAngleY(this Transform me, float newY)
        {
            Vector3 newRot = me.eulerAngles;
            newRot.y = newY;
            me.eulerAngles = newRot;
        }
        public static void SetAngleZ(this Transform me, float newZ)
        {
            Vector3 newRot = me.eulerAngles;
            newRot.z = newZ;
            me.eulerAngles = newRot;
        }
        #endregion

        #region Set LocalAngle

        public static void SetLocalAngle(this Transform me, Vector3 newRot)
        {
            me.localEulerAngles = newRot;
        }
        public static void SetLocalAngleX(this Transform me, float newX)
        {
            me.localEulerAngles = new Vector3(newX, me.transform.localEulerAngles.y, me.transform.localEulerAngles.z);
        }
        public static void SetLocalAngleY(this Transform me, float newY)
        {
            me.localEulerAngles = new Vector3(me.localEulerAngles.x, newY, me.localEulerAngles.z);
        }
        public static void SetLocalAngleZ(this Transform me, float newZ)
        {
            me.localEulerAngles = new Vector3(me.localEulerAngles.x, me.localEulerAngles.y, newZ);
        }
        #endregion

        #region Add Pos

        public static void Add(this Transform me, Vector3 newPos)
        {
            me.position += newPos;
        }
        public static void AddX(this Transform me, float newX)
        {
            Vector3 pos = me.position;
            pos.x += newX;
            me.position = pos;
        }
        public static void AddY(this Transform me, float newY)
        {
            Vector3 pos = me.position;
            pos.y += newY;
            me.position = pos;
        }
        public static void AddZ(this Transform me, float newZ)
        {
            Vector3 pos = me.position;
            pos.z += newZ;
            me.position = pos;
        }
        #endregion

        #region Add LocalPos
        public static void AddLocalPos(this Transform me, Vector3 newPos)
        {
            me.localPosition += newPos;
        }
        public static void AddLocalPosX(this Transform me, float newX)
        {
            me.localPosition += new Vector3(newX, 0, 0);
        }
        public static void AddLocalPosY(this Transform me, float newY)
        {
            me.localPosition += new Vector3(0, newY, 0);
        }
        public static void AddLocalPosZ(this Transform me, float newZ)
        {
            me.localPosition += new Vector3(0, 0, newZ);
        }
        #endregion

        #region Add Angle

        public static void AddAngle(this Transform me, Vector3 newRot)
        {
            me.eulerAngles += newRot;
        }
        public static void AddAngleX(this Transform me, float newX)
        {
            Vector3 newRot = me.eulerAngles;
            newRot.x += newX;
            me.eulerAngles = newRot;
        }

        public static void AddAngleY(this Transform me, float newY)
        {
            Vector3 newRot = me.eulerAngles;
            newRot.y += newY;
            me.eulerAngles = newRot;
        }
        public static void AddAngleZ(this Transform me, float newZ)
        {
            Vector3 newRot = me.eulerAngles;
            newRot.z += newZ;
            me.eulerAngles = newRot;
        }
        #endregion

        #region Add LocalAngle

        public static void AddLocalAngle(this Transform me, Vector3 newRot)
        {
            me.localEulerAngles += newRot;
        }
        public static void AddLocalAngleX(this Transform me, float newX)
        {
            me.localEulerAngles += new Vector3(newX, 0, 0);
        }
        public static void AddLocalAngleY(this Transform me, float newY)
        {
            me.localEulerAngles += new Vector3(0, newY, 0);
        }
        public static void AddLocalAngleZ(this Transform me, float newZ)
        {
            me.localEulerAngles += new Vector3(0, 0, newZ);
        }
        #endregion

        #region GetChild Extension

        public static Transform GetChildWithIndex(this Transform me, int index)
        {
            return me.GetChild(index);
        }
        public static Transform GetFirstChild(this Transform me)
        {
            return me.GetChild(0);
        }

        public static Transform GetLastChild(this Transform me)
        {
            return me.GetChild(me.childCount - 1);
        }

        public static Transform FindDeepChildWithName(this Transform aParent, string aName)
        {
            var result = aParent.Find(aName);
            if (result != null)
                return result;
            foreach (Transform child in aParent)
            {
                result = child.FindDeepChildWithName(aName);
                if (result != null)
                    return result;
            }
            return null;
        }

        public static void SetActiveChildren(this Transform aParent, bool isActive, int from, int to)
        {
            for (int i = from; i < to; i++)
            {
                aParent.GetChild(i).gameObject.SetActive(isActive);
            }
            for (int j = to; j < aParent.transform.childCount; j++)
            {
                aParent.GetChild(j).gameObject.SetActive(!isActive);
            }
        }

        public static void KCAddChild(this Transform aParent, Transform child)
        {
            child.SetParent(aParent);
        }
        #endregion
    }
}
