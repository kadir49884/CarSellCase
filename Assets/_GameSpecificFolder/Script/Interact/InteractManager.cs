using System;
using UnityEngine;

public class InteractManager : Singleton<InteractManager>
{
    public delegate void EnterInteractAction();
    public event EnterInteractAction enterInteractAction;

    public void RegisterEnterInteractAction(EnterInteractAction action)
    {
        enterInteractAction += action;
    }

    public void UnregisterEnterInteractAction(EnterInteractAction action)
    {
        enterInteractAction -= action;
    }




    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && enterInteractAction != null)
        {
            enterInteractAction();
        }
    }



}
