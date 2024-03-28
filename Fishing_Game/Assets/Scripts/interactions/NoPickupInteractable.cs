using System.Collections;
using UnityEngine;

public class NoPickupInteractable : MonoBehaviour, IInteractable
{
    public string AnimationClipName;
    float animationTime;
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
    }

    public void Interact()
    {
        animator.Play(AnimationClipName); // speelt de animatie die match met AnimationClipName
        StartCoroutine(WaitAndDisable());
    }

    private IEnumerator WaitAndDisable()
    {
        yield return new WaitForSeconds(animationTime);
    }

    public string GetInteractionText()
    {
        return "'E'";
    }
}