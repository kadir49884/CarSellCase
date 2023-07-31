using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseRotater : MonoBehaviour
{
    [SerializeField, ReadOnly] private DriveManager driveManager;

    private bool isDriveAcitve;

    [SerializeField] private float sensX = 100f;
    [SerializeField] private float sensY = 100f;

    [SerializeField] Transform cam = null;
    [SerializeField] Transform orientation = null;

    private float mouseX;
    private float mouseY;
    private float multiplier = 0.01f;
    private float xRotation = 0;
    private float yRotation = 90;

    void Start()
    {
        // Script başladığında Coroutine'i başlatın
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        driveManager.DriveActive += DriveActive;
        driveManager.DriveDeactive += DriveDeactive;
        xRotation = 0;
    }



    private void Update()
    {
        if (isDriveAcitve)
            return;

        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");

        yRotation += mouseX * sensX * multiplier;
        xRotation -= mouseY * sensY * multiplier;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cam.transform.rotation = Quaternion.Euler(xRotation, yRotation, cam.transform.rotation.z);
        orientation.transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    private void DriveActive()
    {
        isDriveAcitve = true;
    }

    private void DriveDeactive()
    {
        isDriveAcitve = false;
    }

    // For Optimization
    private void OnValidate()
    {
        SetRef();
    }

    private void SetRef()
    {
        driveManager = DriveManager.Instance;
    }
}
