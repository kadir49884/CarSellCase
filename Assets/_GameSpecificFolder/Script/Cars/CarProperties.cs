using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarProperties : MonoBehaviour
{
    [SerializeField] CarPropertiesScriptableObject carPropertiesScriptableObject;

    public CarPropertiesScriptableObject CarPropertiesScriptableObject { get => carPropertiesScriptableObject; set => carPropertiesScriptableObject = value; }
}
