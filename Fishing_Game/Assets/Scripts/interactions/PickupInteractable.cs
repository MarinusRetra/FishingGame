using System.Collections;
using System.Linq;
using UnityEngine;

public class PickupInteractable : MonoBehaviour, IInteractable
{
    public InventoryItemData itemData;
    public InventoryHolder playerInventoryHolder;
    void Start()
    {
        //  playerInventoryHolder = GameObject.Find("Player").GetComponent<InventoryHolder>();

    }

    public void Interact()
    {
        if (playerInventoryHolder.InventorySystem.AddToInventory(itemData, 1))
        {
            Debug.Log($"{playerInventoryHolder.InventorySystem.InventorySlots.ElementAt(0).ItemData.DisplayName}");
            Destroy(gameObject);
        }
    }
    public string GetInteractionText()
    {
        return $"{itemData.DisplayName}";
    }

}
