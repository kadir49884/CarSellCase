using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CarPropertiesUI : Singleton<CarPropertiesUI>
{
    private CarPropertiesScriptableObject carPropertiesScriptableObject;

    [Header("Car Property Values")]
    [SerializeField] private Transform carPropertiesPanel;
    [SerializeField] private TextMeshProUGUI marketPriceValueText;
    [SerializeField] private TextMeshProUGUI priceValueText;
    [SerializeField] private TextMeshProUGUI damageValueText;
    [SerializeField] private TextMeshProUGUI speedValueText;
    [SerializeField] private TextMeshProUGUI paintValueText;
    [SerializeField] private TextMeshProUGUI torqueValueText;
    [SerializeField] private TextMeshProUGUI suspensionValueText;
    [SerializeField] private TextMeshProUGUI camberValueText;

    [Header("Image Fill Properties")]
    [SerializeField] private Image damageFillValue;
    [SerializeField] private Image paintFillValue;
    [SerializeField] private Image suspensionFillValue;



    public void ShowCarPropertiesPanel()
    {
        SetCarProperties();
        carPropertiesPanel.gameObject.SetActive(true);
    }
    public void HideCarPropertiesPanel()
    {
        carPropertiesPanel.gameObject.SetActive(false);
    }

    public void SetCarProperties()
    {
        carPropertiesScriptableObject = DataOperations.Instance.gameDatas.ActiveCarProperties;
        marketPriceValueText.text = "$" + carPropertiesScriptableObject.CarMarketPrice.ToString();
        priceValueText.text = "$" + carPropertiesScriptableObject.CarNetPrice.ToString();
        damageValueText.text = (carPropertiesScriptableObject.DamageValue * 100).ToString("F0");
        speedValueText.text = carPropertiesScriptableObject.SpeedValue.ToString("F0");
        paintValueText.text = (carPropertiesScriptableObject.PaintValue * 100).ToString("F0");
        torqueValueText.text = carPropertiesScriptableObject.Torquevalue.ToString("F0");
        suspensionValueText.text = carPropertiesScriptableObject.SuspensionValue.ToString("F0");
        camberValueText.text = carPropertiesScriptableObject.CamberValue.ToString("F0");

        damageFillValue.fillAmount = 0;
        paintFillValue.fillAmount = 0;
        suspensionFillValue.fillAmount = 0;

        DOTween.To(value => damageFillValue.fillAmount = value, 0, carPropertiesScriptableObject.DamageValue, 1);
        DOTween.To(value => paintFillValue.fillAmount = value, 0, carPropertiesScriptableObject.PaintValue, 1);
        DOTween.To(value => suspensionFillValue.fillAmount = value, 0, carPropertiesScriptableObject.SuspensionValue / 100, 1);

    }


}
