using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : Singleton<CanvasManager>
{
    [SerializeField] private GameObject interactPromptE;
    [SerializeField] private Text interactMessageText;
    [SerializeField, ReadOnly] private CanvasGroup canvasGroup;
    [SerializeField, ReadOnly] private InteractManager interactManager;


    public void ActiveInteractHelper(string getInteractMessage)
    {
        interactMessageText.text = getInteractMessage;
        canvasGroup.alpha = 1;
        interactManager.RegisterEnterInteractAction(DeactiveInteractHelper);
    }
    public void DeactiveInteractHelper()
    {
        interactManager.UnregisterEnterInteractAction(DeactiveInteractHelper);
        canvasGroup.alpha = 0;
    }


    // For Optimization
    private void OnValidate()
    {
        SetRef();
    }

    private void SetRef()
    {
        canvasGroup = interactPromptE.GetComponent<CanvasGroup>();
        interactManager = InteractManager.Instance;
    }

}
