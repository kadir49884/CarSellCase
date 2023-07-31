using UnityEngine;

[CreateAssetMenu(fileName = "CarProperties", menuName = "KadirExtension/CarProperties")]
public class CarPropertiesScriptableObject : ScriptableObject
{
    [Header("CarPrice")]
    [SerializeField] private float carNetPrice = 50000;
    [SerializeField] private float carMarketPrice = 50000;

    [Header("PriceFactors")]
    [Range(0f, 1f)]
    [SerializeField] private float damageValue = 0.1f;    // 0 to 1 values
    [Range(0f, 1f)]
    [SerializeField] private float paintValue = 0.1f;     // 0 to 1 values
    [SerializeField] private float speedValue = 220;
    [SerializeField] private float torquevalue = 190;

    [Header("OtherProperties")]
    [Range(0f, 100f)]
    [SerializeField] private float suspensionValue = 30; // 0 to 100 values
    [Range(-10f, 10f)]
    [SerializeField] private float camberValue = 0; // -10 to 10 values

    public float CarNetPrice { get => carNetPrice; set => carNetPrice = value; }
    public float CarMarketPrice { get => carMarketPrice; set => carMarketPrice = value; }
    public float DamageValue { get => damageValue; set => damageValue = value; }
    public float PaintValue { get => paintValue; set => paintValue = value; }
    public float SuspensionValue { get => suspensionValue; set => suspensionValue = value; }
    public float SpeedValue { get => speedValue; set => speedValue = value; }
    public float Torquevalue { get => torquevalue; set => torquevalue = value; }
    public float CamberValue { get => camberValue; set => camberValue = value; }
}