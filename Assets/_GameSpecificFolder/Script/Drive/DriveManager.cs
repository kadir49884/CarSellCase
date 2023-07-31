using DG.Tweening;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

public class DriveManager : Singleton<DriveManager>
{
    [SerializeField, ReadOnly] private Transform playerTransform;
    [SerializeField, ReadOnly] private ObjectManager objectManager;
    [SerializeField, ReadOnly] private Transform cameraHolderFPS;

    public Action DriveActive { get; set; }
    public Action DriveDeactive { get; set; }

    public void GetInCar(Transform getCar, Transform cameraPosInCar)
    {
        DriveActive();

        playerTransform.transform.parent = getCar;
        playerTransform.gameObject.SetActive(false);
        cameraHolderFPS.parent = cameraPosInCar;
        objectManager.Rcc_Camera.ChangeCamera(RCC_Camera.CameraMode.FPS);
        objectManager.RccCameraObject.gameObject.SetActive(true);

    }


    public void GetOutCar(Transform getOutPos)
    {
        SetPlayerOutPos(playerTransform, getOutPos);
        DriveDeactive();
        objectManager.RccCameraObject.gameObject.SetActive(false);

    }

    private void SetPlayerOutPos(Transform getTransform, Transform getOutPos)
    {
        getTransform.gameObject.SetActive(true);
        getTransform.parent = null;
        getTransform.position = getOutPos.position;
        getTransform.eulerAngles = getOutPos.eulerAngles;
    }


    // For Optimization
    private void OnValidate()
    {
        SetRef();
    }

    private void SetRef()
    {
        playerTransform = PlayerDriveChecker.Instance.transform;
        cameraHolderFPS = ObjectManager.Instance.CameraHolderFPS;
    }
}
