using TMPro;
using UnityEngine;

public class Crossair : MonoBehaviour
{
   public GameObject interactionText, Cross;
    // dit script zet de crossair uit als je naar een interactable kijkt

    void Update()
    {
        if (interactionText.activeSelf)
        {
            Cross.SetActive(false);
        }
        else
        {
            Cross.SetActive(true);
        }
    }
}
