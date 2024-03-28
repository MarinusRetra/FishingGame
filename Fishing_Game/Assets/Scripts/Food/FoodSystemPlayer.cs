using UnityEngine.UI;
using UnityEngine;

public class FoodSystemPlayer : MonoBehaviour
{
    public int HungerMultiplier = 1; // hoe snel eten naarbeneden gaat
    public static Slider ThirstMeter;
    public static Slider HungerMeter;

    private void Start()
    {
        ThirstMeter = GameObject.Find("ThirstBar").GetComponent<Slider>();
        HungerMeter = GameObject.Find("HungerBar").GetComponent<Slider>();

    }
    void Update()
    {
        ThirstMeter.value -= Time.deltaTime * HungerMultiplier;
        HungerMeter.value -= Time.deltaTime * HungerMultiplier;
    }

    public static void AddFood(int amountFood = 0, int amountWater = 0)
    {
        ThirstMeter.value += amountWater;
        HungerMeter.value += amountFood;
    }
}
