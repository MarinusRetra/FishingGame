using UnityEngine;
using TMPro;
public class TimeSystem : MonoBehaviour
{
    const int hoursInDay = 24, minutesPerHour = 60; // hoeveel uren in een dag en minuten in een uur

    public float dayDuration = 1200f;// hoelang de dag duurt in seconden

    [SerializeField] float totaltime = 0, currentTime = 0; // totalTime is tijd sinds start TimeSystem, CurrentTime is hoeveel tijd er op een dag is verstreken

    TextMeshProUGUI clockText; // de string die weergegeven wordt in de PlayerUI

    Transform sunTransform; // gebruikt voor het draaien van de zon op basis van tijd

    private void Start()
    {
        clockText = GameObject.Find("TimeText").GetComponent<TextMeshProUGUI>();
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
        Clock24();
    }

    public float GetHour()
    { 
        return currentTime * hoursInDay / dayDuration;
    }
    public float GetMinutes()
    {
        return (currentTime * hoursInDay * minutesPerHour / dayDuration) % minutesPerHour;
    }

    /// <summary>
    /// Zet de tijd in formaat van een vierentwinteg uur klok
    /// </summary>
    public void Clock24()
    {
        string time = $"{Mathf.FloorToInt(GetHour()):00}:{Mathf.FloorToInt(GetMinutes()):00} "; //:00 doet hetzelfde als ToString("00")
        SetClock(time);
    }
    /// <summary>
    /// Zet de tijd van de clock op het scherm en draait de zon mee
    /// </summary>
    /// <param name="insertTime"></param>
    public void SetClock(string insertTime)
    {
        clockText.text = insertTime;
        SetSun();
    }

    public void SetSun()
    {
        float rotationAngle = (360f * GetHour()) / hoursInDay;
        sunTransform.rotation = Quaternion.Euler(new Vector3(rotationAngle, 0f, 0f));
    }
    /// <summary>
    /// Zet de klok 8 uur naarvoren
    /// </summary>
    public void Sleep()
    {
        totaltime += 400f;
        Clock24();
    }


}
