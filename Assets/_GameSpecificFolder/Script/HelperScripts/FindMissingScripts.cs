using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class FindMissingScripts : MonoBehaviour
{
#if UNITY_EDITOR
    public List<GameObject> missingObjectList;
    public bool doList;
    public bool doDestroyComponent;

    [Button]
    public void FindScripts()
    {
        missingObjectList.Clear();
        Transform[] ts = GetComponentsInChildren<Transform>(true);

        foreach (Transform t in ts)
        {
            Component[] cs = t.gameObject.GetComponents<Component>();
            foreach (Component c in cs)
            {
                if (c == null)
                {
                    if (doList)
                        missingObjectList.Add(t.gameObject);
                    if (doDestroyComponent)
                        GameObjectUtility.RemoveMonoBehavioursWithMissingScript(t.gameObject);
                }
            }
        }

        if (doDestroyComponent)
            missingObjectList.Clear();
    }
#endif
}