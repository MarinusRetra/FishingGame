using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NoPickupInteractable : MonoBehaviour, IInteractable
{
    public string AnimationClipName;
    public string AnimationClipName2;
    float animationTime;
    float animationTime2;

    bool toggle = true;

    Animator animator;

    void Start()
    {
        Interactor InteractionScript = GameObject.Find("PlayerCamera").GetComponent<Interactor>();

        animator = gameObject.GetComponent<Animator>();

        // pakt alle clips van de animatior zoekt eentje met Consume, pakt daarvan de animatie tijd en zet die in de waitforseconds
        AnimationClip[] animationClips = animator.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in animationClips)
        {
            if (clip.name == AnimationClipName) // dit werkt als de clip dezelfde naam heeft als de AnimationInteractable
            {
                animationTime = clip.length;
                break;
            }
        }

        if (AnimationClipName2 != "")
        {
            foreach (AnimationClip clip in animationClips)
            {
                if (clip.name == AnimationClipName2) // dit werkt als de clip dezelfde naam heeft als de AnimationInteractable
                {
                    animationTime2 = clip.length;
                    break;
                }
            }
        }
    }

    public void Interact()
    {
        if (toggle)
        {
        animator.Play(AnimationClipName); // speelt de animatie die matcht met AnimationClipName
        }
        else 
        {
            animator.Play(AnimationClipName2);
        }

        if (AnimationClipName2 != "") // toggled alleen als AnimarionClipName2 een waarde heeft
        {
           toggle = !toggle;
        }
    }

    private IEnumerator WaitAndDisable()
    {
        yield return new WaitForSeconds(animationTime);
    }

    public string GetInteractionText()
    {
        return toggle ?  "Open" : "Close";
    }
}