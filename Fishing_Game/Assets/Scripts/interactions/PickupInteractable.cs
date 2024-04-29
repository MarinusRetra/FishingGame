using System.Collections.Generic;
using UnityEngine;

public class PickupInteractable : MonoBehaviour, IInteractable
{
    public InventoryItemData itemData;
    InventoryHolder playerInventoryHolder;

    public static List<GameObject> HarvestedItems = new List<GameObject>();

    void Start()
    {
        playerInventoryHolder = GameObject.Find("Player").GetComponent<InventoryHolder>();
    }

    public void Interact()
    {
        if (playerInventoryHolder.InventorySystem.AddToInventory(itemData, 1))
        {
            if (itemData.GetType() != typeof(Equipment))
            { 
                HarvestedItems.Add(gameObject);
            }
            gameObject.SetActive(false);
        }
    }
    public string GetInteractionText()
    {
        return $"{itemData.DisplayName}";
    }
}
