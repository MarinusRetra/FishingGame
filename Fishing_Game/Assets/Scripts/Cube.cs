using System;
using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    bool isOpen = true;

    public Interactor InteractionScript;
    public Material OutlineMat;
    public string OutlineScale;

    Animator animator;

    void Start()
    { 
      animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (InteractionScript.isHovering)
        { 
          OutlineMat.SetFloat(OutlineScale, 1.03f);
        }
        else
        OutlineMat.SetFloat(OutlineScale, 0f);
    }


    private IEnumerator WaitAndDisable()
    {
        yield return new WaitForSeconds(0.8f);
        isOpen = !isOpen;
    }

    public void Interact()
    {
        if (isOpen)
        {
            animator.Play("Open");
        }
        else
            animator.Play("Close");

        StartCoroutine(WaitAndDisable());
    }

    public string GetInteractionText()
    {
        return isOpen ? "Open" : "Close";

    }
}
