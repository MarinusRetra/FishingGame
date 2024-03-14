using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Food : MonoBehaviour
{
    public int HungerMultiplier = 1;
    public Slider ThirstMeter;
    public Slider HungerMeter;
    void Update()
    {
        ThirstMeter.value -= Time.deltaTime * HungerMultiplier;
        HungerMeter.value -= Time.deltaTime * HungerMultiplier;
    }

    public void AddFood(int amountFood = 0, int amountWater = 0)
    {
        ThirstMeter.value += amountWater;
        HungerMeter.value += amountFood;
    }
}
