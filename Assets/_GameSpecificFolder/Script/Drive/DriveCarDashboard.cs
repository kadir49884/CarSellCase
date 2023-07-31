using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveCarDashboard : MonoBehaviour
{
    [SerializeField, ReadOnly] private DriveManager driveManager;
    [SerializeField, ReadOnly] private RCC_UIDashboardDisplay rcc_UIDashboardDisplay;


    private void Start()
    {
        driveManager.DriveActive += DriveActive;
        driveManager.DriveDeactive += DriveDeactive;
    }

    private void DriveActive()
    {
        rcc_UIDashboardDisplay.SetDisplayType(RCC_UIDashboardDisplay.DisplayType.Full);
    }
    private void DriveDeactive()
    {
        rcc_UIDashboardDisplay.SetDisplayType(RCC_UIDashboardDisplay.DisplayType.Off);
    }

    // For Optimization
    private void OnValidate()
    {
        SetRef();
    }

    private void SetRef()
    {
        driveManager = DriveManager.Instance;
        rcc_UIDashboardDisplay = GetComponent<RCC_UIDashboardDisplay>();
    }

}
