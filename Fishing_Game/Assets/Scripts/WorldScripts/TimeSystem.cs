using UnityEngine;
using TMPro;
public class TimeSystem : MonoBehaviour
{
    const int hoursInDay = 24, minutesPerHour = 60; // hoeveel uren in een dag en minuten in een uur

    public float dayDuration = 1200f;// hoelang de dag duurt in seconden

    [SerializeField] float totaltime = 0, currentTime = 0; // totalTime is tijd sinds start TimeSystem, CurrentTime is hoeveel tijd er op een dag is verstreken

    GameObject clockText;
    Transform sunTransform; 

    private void Start()
    {
        clockText = GameObject.Find("TimeText");
        sunTransform = GameObject.Find("Sun").transform;
    }

    void Update()
    {

        totaltime += Time.deltaTime;
        currentTime = totaltime % dayDuration; // zorgt dat currentime altijd tussen 0 en hoursInDay zit

        //Deubugging
        if (Input.GetKeyDown(KeyCode.P))
        {
            totaltime += 100f;
        }
        clockText.GetComponent<TextMeshProUGUI>().text = Clock24();
        SetSun();
    }

    public float GetHour()
    { 
        return currentTime * hoursInDay / dayDuration;
    }

    public float GetMinutes()
    {
        return (currentTime * hoursInDay * minutesPerHour / dayDuration) % minutesPerHour;
    }

    public string Clock24()
    {
        return $"{Mathf.FloorToInt(GetHour()):00}:{Mathf.FloorToInt(GetMinutes()):00} "; //:00 doet hetzelfde als ToString("00")
    }

    public void SetSun()
    {
        float rotationAngle = (360f * GetHour()) / hoursInDay;
        sunTransform.rotation = Quaternion.Euler(new Vector3(rotationAngle, 0f, 0f));
    }

    public void Sleep()
    {
        currentTime = 400f;
        totaltime += 1200f + currentTime;
    }


}
