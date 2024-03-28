using System.Collections;
using UnityEngine;

public class PickupInteractable : MonoBehaviour, IInteractable
{
    public InventoryItemData itemData;
    public InventoryHolder  playerInventoryHolder;
    void Start()
    { 
      //  playerInventoryHolder = GameObject.Find("Player").GetComponent<InventoryHolder>();
    }

    public void Interact()
    {
        if (playerInventoryHolder.InventorySystem.AddToInventory(itemData, 1))
        {
            Destroy(gameObject);
        }
    }
    public string GetInteractionText()
    {
        return $"{itemData.DisplayName}";
    }

}
