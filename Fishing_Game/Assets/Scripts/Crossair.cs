using TMPro;
using UnityEngine;

public class Crossair : MonoBehaviour
{
    GameObject interactionText;
    // dit hele script zet de crossair uit als je naar een interactable kijkt
    void Start()
    {
       interactionText = GameObject.Find("InteractionText");
    }

    // Update is called once per frame
    void Update()
    {
        if (interactionText.activeSelf)
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = "";
        }
        else
        { 
            gameObject.GetComponent<TextMeshProUGUI>().text = ".";
        }
    }
}
