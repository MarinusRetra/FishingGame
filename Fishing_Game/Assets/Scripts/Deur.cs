using System;
using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public GameObject Deur;
    
    private IEnumerator WaitAndDisable()
    {
        yield return new WaitForSeconds(1.8f);
        Destroy(Deur);
    }

    public void Interact()
    {
          StartCoroutine(WaitAndDisable());
    }

    public string GetInteractionText()
    {
        return "Open";
    }
}
