using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BedInteract : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        GameObject.Find("Clock").GetComponent<TimeSystem>().Sleep();
    }

    public string GetInteractionText()
    {
        return "Bed";
    }
}