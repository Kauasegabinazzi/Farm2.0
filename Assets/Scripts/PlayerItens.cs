using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItens : MonoBehaviour
{
    [SerializeField] private int totalWood;
    public float currentWater;
    public int carrots;
    public int fishes;

    private float waterLimit;
    private float carrotLimit;
    private float woodLimit;
    private float fishesLimit;

    public int TotalWood { get => totalWood; set => totalWood = value; }
    public float WaterLimit1 { get => waterLimit; set => waterLimit = value; }
    public float CarrotLimit { get => carrotLimit; set => carrotLimit = value; }
    public float WoodLimit { get => woodLimit; set => woodLimit = value; }
    public float FishesLimit { get => fishesLimit; set => fishesLimit = value; }

    void Start()
    {
        waterLimit = 50;
        woodLimit = 10;
        carrotLimit = 10;
        fishesLimit = 5;
    }

    public void WaterLimit(int water)
    {
        if (currentWater <= waterLimit)
        {
            currentWater += water;
        }
    }
}
