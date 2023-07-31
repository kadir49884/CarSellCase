using Sirenix.OdinInspector;
using UnityEngine;

public class InteractCar : BaseInteract, IInteractable
{
    [SerializeField, ReadOnly] private RCC_CarControllerV3 rCC_CarControllerV3;
    [SerializeField, ReadOnly] private Transform camPosInCar;
    [SerializeField, ReadOnly] private Transform getOutPos;
    private DriveManager driveManager;
    private bool isPlayerCar;

    public bool IsPlayerCar { get => isPlayerCar; set => isPlayerCar = value; }

    private void Awake()
    {
        gameDatas = DataOperations.Instance.gameDatas;
        driveManager = DriveManager.Instance;
        canvasManager = CanvasManager.Instance;
        interactManager = InteractManager.Instance;
    }
    public void InInteractObject()
    {
        if(IsPlayerCar)
        {
            canvasManager.ActiveInteractHelper(gameDatas.interactMessages.CarMessage);
            interactManager.RegisterEnterInteractAction(EnterInteract);
        }
        else
        {
            canvasManager.ActiveInteractHelper(gameDatas.interactMessages.CarNegativeMessage);
        }

    }

    public void OutInteractObject()
    {
        interactManager.UnregisterEnterInteractAction(EnterInteract);
    }

    public void EnterInteract()
    {

        if (!rCC_CarControllerV3.enabled)
        {
            Debug.Log("EnterInteractCar");
            driveManager.GetInCar(transform.parent, camPosInCar);
            rCC_CarControllerV3.enabled = true;
        }
        else
        {
            Debug.Log("ExitInteractCar");
            rCC_CarControllerV3.enabled = false;
            driveManager.GetOutCar(getOutPos);

        }
    }


    // For Optimization

    private void OnValidate()
    {
        SetRef();
    }

    private void SetRef()
    {
        rCC_CarControllerV3 = transform.parent.GetComponent<RCC_CarControllerV3>();
        camPosInCar = transform.parent.GetComponentInChildren<CameraPosInCar>().transform;
        getOutPos = transform.parent.GetComponentInChildren<GetOutPosCar>().transform;
        
    }


}
