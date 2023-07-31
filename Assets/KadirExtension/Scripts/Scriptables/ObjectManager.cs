using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : Singleton<ObjectManager>
{
	[SerializeField] private Camera orthoCamera;
	[SerializeField] private Transform cameraHolderFPS;
	[SerializeField] private Transform rccCameraObject;
	[SerializeField] private RCC_Camera rcc_Camera;

    public Camera OrthoCamera { get => orthoCamera; set => orthoCamera = value; }
    public Transform CameraHolderFPS { get => cameraHolderFPS; set => cameraHolderFPS = value; }
    public Transform RccCameraObject { get => rccCameraObject; set => rccCameraObject = value; }
    public RCC_Camera Rcc_Camera { get => rcc_Camera; set => rcc_Camera = value; }
}