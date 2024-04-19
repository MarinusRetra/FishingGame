using System.Collections;
using System.Linq;
using UnityEngine;

public class PickupInteractable : MonoBehaviour, IInteractable
{
    public InventoryItemData itemData;
    InventoryHolder playerInventoryHolder;
    void Start()
    {
        playerInventoryHolder = GameObject.Find("Player").GetComponent<InventoryHolder>();
    }

    public void Interact()
    {
        if (playerInventoryHolder.InventorySystem.AddToInventory(itemData, 2))
        {
            Destroy(gameObject);
        }
    }
    public string GetInteractionText()
    {
        return $"{itemData.DisplayName}";
    }

}
