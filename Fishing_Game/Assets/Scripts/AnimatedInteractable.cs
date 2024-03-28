using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="AnimatedInteractable" , menuName = "InteractableNoPickup")]
public class AnimatedInteractable : ScriptableObject
{
    public string AnimationClipName;// naam van de animatie in de controller die je wilt gebruiken
}
