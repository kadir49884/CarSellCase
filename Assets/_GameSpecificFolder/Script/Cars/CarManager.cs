using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    [SerializeField, ReadOnly] private CarRandomizer carRandomizer;
    [SerializeField, ReadOnly] private CarPriceCalculator carPriceCalculator;
    [SerializeField, ReadOnly] private InteractCar interactCar;

    public InteractCar InteractCar { get => interactCar; set => interactCar = value; }

    //[SerializeField, ReadOnly] private SellerController sellerController;


    private void Start()
    {
        carRandomizer.CarRandomizing();
        carPriceCalculator.PriceCalculate();
        //sellerController.SetSellerDialog();
        
    }

    // For Optimization
    private void OnValidate()
    {
        SetRef();
    }

    private void SetRef()
    {
        carRandomizer = GetComponent<CarRandomizer>();
        carPriceCalculator = GetComponent<CarPriceCalculator>();
        InteractCar = GetComponentInChildren<InteractCar>();
        //sellerController = GetComponentInChildren<SellerController>();
    }
}
