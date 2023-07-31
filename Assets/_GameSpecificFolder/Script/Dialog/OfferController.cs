using DG.Tweening;
using PixelCrushers;
using PixelCrushers.DialogueSystem;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OfferController : Singleton<OfferController>
{

    private string offerValueString;
    private string fieldStartText;
    private float carNetPrice;
    private float offerValue;
    private SellerController sellerController;
    private GameDatas gameDatas;

    [SerializeField] private TextMeshProUGUI offerResult;
    [SerializeField] private Transform offerElementParent;
    [SerializeField, ReadOnly] private CanvasGroup canvasGroup;
    [SerializeField, ReadOnly] private TMP_InputField inputField;
    private void Start()
    {
        inputField.onValidateInput += ValidateInput;
        fieldStartText = inputField.text;
        gameDatas = DataOperations.Instance.gameDatas;
    }

    public void GetInputFieldString(string inputFieldString)
    {
        offerValueString = inputFieldString;
    }

    public void GiveOffer()
    {
        if (offerValueString == null || offerValueString == "")
        {
            return;
        }

        if (sellerController != null)
        {
            OfferChecker();
        }

    }


    private void OfferChecker()
    {

        DialogueManager.instance.conversationEnded += OnConversationEnd;

        offerValue = float.Parse(offerValueString);
        carNetPrice = sellerController.CarPropertiesScriptableObject.CarNetPrice;
        offerElementParent.gameObject.SetActive(false);
        if (offerValue > carNetPrice * 0.5f)
        {
            OfferAccepted();
        }
        else
        {
            OfferRejected();
        }
        offerResult.gameObject.SetActive(true);
    }

    private void OfferAccepted()
    {
        // Offer accepted
        sellerController.BargainBuy();
        offerResult.color = Color.green;
        offerResult.text = gameDatas.offerMessage.AcceptedMessage;

        DOVirtual.DelayedCall(2, () =>
        {
            sellerController.ConversationFinished();
            ResetOfferPanel();
        });
    }

    private void OfferRejected()
    {
        // Offer rejected
        offerResult.color = Color.red;
        offerResult.text = gameDatas.offerMessage.RejectedMessage;
        DOVirtual.DelayedCall(2, () =>
        {
            sellerController.ConversationFinished();
            ResetOfferPanel();
        });
    }

    public void OnConversationEnd(Transform actor)
    {
        ResetOfferPanel();
    }
   
    public void ShowOfferPanel(SellerController getSellerController)
    {
        canvasGroup.alpha = 1;
        sellerController = getSellerController;
    }
    public void ResetOfferPanel()
    {
        canvasGroup.alpha = 0;
        offerElementParent.gameObject.SetActive(true);
        inputField.text = fieldStartText;
        offerResult.gameObject.SetActive(false);

    }


    private char ValidateInput(string text, int charIndex, char addedChar)
    {
        if (char.IsDigit(addedChar) || addedChar == '-' || addedChar == '+')
        {
            return addedChar;
        }

        return '\0';
    }



    // For Optimization
    private void OnValidate()
    {
        SetRef();
    }

    private void SetRef()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        inputField = GetComponentInChildren<TMP_InputField>();
    }


}
