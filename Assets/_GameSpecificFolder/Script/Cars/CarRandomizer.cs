using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRandomizer : MonoBehaviour
{
    [SerializeField, ReadOnly] private CarPropertiesScriptableObject carPropertiesScriptableObject;
    private void OnValidate()
    {
        SetRef();
    }

    private void SetRef()
    {
        carPropertiesScriptableObject = GetComponent<CarProperties>().CarPropertiesScriptableObject;
    }

    public void CarRandomizing()
    {
        carPropertiesScriptableObject.CarMarketPrice = Random.Range(10000, 100000);
        carPropertiesScriptableObject.DamageValue = Random.Range(0f, 1f);
        carPropertiesScriptableObject.PaintValue = Random.Range(0f, 1f);
        carPropertiesScriptableObject.SpeedValue = Random.Range(100f, 350f);
        carPropertiesScriptableObject.Torquevalue = Random.Range(100f, 300f);
        carPropertiesScriptableObject.SuspensionValue = Random.Range(0f, 100f);
        carPropertiesScriptableObject.CamberValue = Random.Range(-10f, 10f);
    }
}
