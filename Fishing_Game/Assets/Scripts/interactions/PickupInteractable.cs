using System.Collections;
using UnityEngine;

public class PickupInteractable : MonoBehaviour, IInteractable
{

    void Start()
    { 
        InventoryHolder playerInventoryHolder = GameObject.Find("Player").GetComponent<InventoryHolder>();

    }

    public void Interact()
    {
        Destroy(gameObject);
    }
    public string GetInteractionText()
    {
        return "'E'";
    }

    private void OnDestroy()
    {
        // hier komt add invetory logic
    }
}
