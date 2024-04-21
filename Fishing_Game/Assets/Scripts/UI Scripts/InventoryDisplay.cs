using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class InventoryDisplay : MonoBehaviour
{
    [SerializeField] MouseItemData mouseInventoryItem;

    protected InventorySystem inventorySystem;
    protected Dictionary<InventorySlot_UI, InventorySlot> slotDictionary;

    protected virtual void Start()
    { 
    
    }

    public InventorySystem InventorySystem { get { return inventorySystem; } }
    public Dictionary<InventorySlot_UI,InventorySlot> SlotDictionary { get { return slotDictionary; } }

    public abstract void AssignSlot(InventorySystem InvToDisplay);

    protected virtual void UpdateSlot(InventorySlot updatedSlot)
    {
        foreach (var slot in SlotDictionary)
        {
            if (slot.Value == updatedSlot)
            {
                slot.Key.UpdateUISlot(updatedSlot);
            }
        }
    }

    public void SlotClicked(InventorySlot_UI clickedSlot)
    {
        if (clickedSlot.AssignedInventorySlot .ItemData != null)
        { 
           Debug.Log($"Slot Clicked {clickedSlot.AssignedInventorySlot.ItemData.DisplayName}");
           if (clickedSlot.AssignedInventorySlot.ItemData.GetType() == typeof(FoodItem))
           {
               FoodItem eating = (FoodItem)clickedSlot.AssignedInventorySlot.ItemData;
               FoodSystemPlayer.AddFood(eating.FoodAmount, eating.WaterAmount);
               clickedSlot.AssignedInventorySlot.ClearSlot();
               clickedSlot.AssignedInventorySlot.UpdateInventorySlot(clickedSlot.AssignedInventorySlot.ItemData, clickedSlot.AssignedInventorySlot.StackSize);
               clickedSlot.UpdateUISlot();
           }
        }
    }

}
