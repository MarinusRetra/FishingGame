using System.Collections;
using UnityEngine;

public class NoPickupInteractable : MonoBehaviour, IInteractable
{
    public AnimatedInteractable AnimInteractable;
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
            if (clip.name == AnimInteractable.AnimationClipName) // dit werkt als de clip dezelfde naam heeft als het scriptable object
            {
                animationTime = clip.length;
                break;
            }
        }
    }

    public void Interact()
    {
        animator.Play(foodValues.name); // speelt de animatie die match met de naam van het FoodType scriptable object
        StartCoroutine(WaitAndDisable());
    }

    private IEnumerator WaitAndDisable()
    {
        yield return new WaitForSeconds(animationTime);
        Destroy(gameObject); // verwijderd het object nadat de animatie klaar is
    }

    public string GetInteractionText()
    {
        return "'E'";
    }

    private void OnDestroy()
    {
        Debug.Log(animationTime);
        FoodSystemPlayer.AddFood(foodValues.FoodAmount, foodValues.WaterAmount);
    }
}