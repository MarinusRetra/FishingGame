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
        if (playerInventoryHolder.InventorySystem.AddToInventory(itemData, 1))
        {// print de hele inventaris naar de console omdat ik niet in de inspecter de waardes kan bekijken
            foreach (var item in playerInventoryHolder.InventorySystem.InventorySlots) 
            {
                if (item.ItemData != null)
                {
                    Debug.Log($"{playerInventoryHolder.InventorySystem.InventorySlots.ElementAt(playerInventoryHolder.InventorySystem.InventorySlots.IndexOf(item)).ItemData.DisplayName}");
                    Debug.Log($"{playerInventoryHolder.InventorySystem.InventorySlots.ElementAt(playerInventoryHolder.InventorySystem.InventorySlots.IndexOf(item)).ItemData.Description}");
                    Debug.Log($"{playerInventoryHolder.InventorySystem.InventorySlots.ElementAt(playerInventoryHolder.InventorySystem.InventorySlots.IndexOf(item)).ItemData.MaxStackSize}");
                }
            }

            Destroy(gameObject);
        }
    }
    public string GetInteractionText()
    {
        return $"{itemData.DisplayName}";
    }

}
