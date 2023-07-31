using DG.Tweening;
using PixelCrushers;
using PixelCrushers.DialogueSystem;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;

public class SellerController : MonoBehaviour
{

    [SerializeField, ReadOnly] private DialogueSystemTrigger dialogueSystemTrigger;
    private float randomGarbainValue;
    private CarPropertiesScriptableObject carPropertiesScriptableObject;
    private InteractCar interactCar;
    private PlayerMouseRotater playerMouseRotater;
    private PlayerMovement playerMovement;
    private DataOperations dataOperations;
    private CarPropertiesUI carPropertiesUI;

    private bool isSaveData;

    public CarPropertiesScriptableObject CarPropertiesScriptableObject { get => carPropertiesScriptableObject; set => carPropertiesScriptableObject = value; }


    private void Awake()
    {
        playerMouseRotater = PlayerDriveChecker.Instance.GetComponent<PlayerMouseRotater>();
        playerMovement = playerMouseRotater.GetComponent<PlayerMovement>();
        dataOperations = DataOperations.Instance;
        carPropertiesUI = CarPropertiesUI.Instance;
        if (carPropertiesUI == null)
        {
            DOVirtual.DelayedCall(2, () =>
            {
                carPropertiesUI = CarPropertiesUI.Instance;
            });
        }
    }
    public void GetCarProperties(Transform getCar)
    {
        carPropertiesScriptableObject = getCar.GetComponent<CarProperties>().CarPropertiesScriptableObject;
        interactCar = getCar.GetComponent<CarManager>().InteractCar;
    }


    public void StartSellerDialog()
    {
        CursorControl.SetCursorActive(true);
        SetCarData();
        PlayerLock();
        SetSellerDialog();
        dialogueSystemTrigger.OnUse();
        carPropertiesUI.ShowCarPropertiesPanel();

    }

    private void SetCarData()
    {
        dataOperations.gameDatas.ActiveCarProperties = carPropertiesScriptableObject;
        carPropertiesUI.SetCarProperties();
    }

    private void PlayerLock()
    {
        playerMouseRotater.enabled = false;
        playerMovement.enabled = false;
    }
    private void PlayerUnLock()
    {
        playerMouseRotater.enabled = true;
        playerMovement.enabled = true;
    }

    public void SetSellerDialog()
    {

        if (isSaveData)
        {
            return;
        }
        isSaveData = true;
        randomGarbainValue = Random.Range(0.1f, 0.2f);
        DialogueLua.SetVariable("CarSellPrice", carPropertiesScriptableObject.CarNetPrice);
        DialogueLua.SetVariable("CarBargain", true);
        Lua.RegisterFunction("BargainBuy", this, SymbolExtensions.GetMethodInfo(() => BargainBuy()));
        Lua.RegisterFunction("DirectBuy", this, SymbolExtensions.GetMethodInfo(() => DirectBuy()));
        Lua.RegisterFunction("SetBargainPrice", this, SymbolExtensions.GetMethodInfo(() => SetBargainPrice()));
        DialogueManager.instance.conversationEnded += OnConversationEnd;
    }


    public void UnRegisterDialog()
    {
        if (!isSaveData)
        {
            return;
        }
        isSaveData = false;
        Lua.UnregisterFunction("BargainBuy");
        Lua.UnregisterFunction("DirectBuy");
        Lua.UnregisterFunction("SetBargainPrice");

    }

    public void ConversationFinished()
    {
        DialogueManager.Instance.StopConversation(); 
        DialogueManager.Instance.DialogueUI.Close();
        PlayerUnLock();
        CursorControl.SetCursorActive(false);
        UnRegisterDialog();

    }

    public void OnConversationEnd(Transform actor)
    {
        ConversationFinished();
    }

  

    public void BargainBuy()
    {
        Debug.Log("BargainBuy");
        interactCar.IsPlayerCar = true;
        DOVirtual.DelayedCall(2, () =>
        {
            gameObject.SetActive(false);

        });
    }
    public void DirectBuy()
    {
        Debug.Log("DirectBuy");
        interactCar.IsPlayerCar = true;
        DOVirtual.DelayedCall(2, () =>
        {
            gameObject.SetActive(false);

        });

    }


    private void SetBargainPrice()
    {

        DialogueLua.SetVariable("CarSellPrice", carPropertiesScriptableObject.CarNetPrice
            - (int)(carPropertiesScriptableObject.CarNetPrice * randomGarbainValue));

        OfferController.Instance.ShowOfferPanel(this);
    }



    private void OnValidate()
    {
        SetRef();
    }

    private void SetRef()
    {
        dialogueSystemTrigger = GetComponent<DialogueSystemTrigger>();
        //carPropertiesScriptableObject = GetComponentInParent<CarProperties>().CarPropertiesScriptableObject;
    }
}
