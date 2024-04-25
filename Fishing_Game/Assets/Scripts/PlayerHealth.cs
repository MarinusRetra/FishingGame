using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 100;
    public static Slider HealthMeter;


    private void Start()
    {
        HealthMeter = GameObject.Find("HealthBar").GetComponent<Slider>();
    }
    void Update()
    {
        if (CheckFood() && health < 101 && health < 100)
        {
            health += Time.deltaTime * 2;
        }
        else if(health > 0 && !CheckFood())
        {
            health -= Time.deltaTime * 4;
        }
        SetHealthBar();
        CheckIfDie();
    }

    private bool CheckFood()
    {
        if (FoodSystemPlayer.ThirstMeter.value <= 0)
        {
            return false;
        }
        if (FoodSystemPlayer.HungerMeter.value <= 0)
        {
            return false;
        }
        return true;
    }

    private void SetHealthBar()
    {
        HealthMeter.value = health;
    }

    void CheckIfDie()
    {
        if (health < 1)
        {
            Die();
        }
    }

    public void Die() // verander chest naar het bed object later
    {
        GameObject.Find("Player").GetComponent<CharacterController>().enabled = false;
        GameObject.Find("Player").transform.position = new Vector3(80, 7, 160);
        GameObject.Find("Player").GetComponent<CharacterController>().enabled = true;
        FoodSystemPlayer.HungerMeter.value = 1000f;
        FoodSystemPlayer.ThirstMeter.value = 1000f;
        health = 100;
    }
}
