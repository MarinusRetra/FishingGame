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

    public void SlotClicked(InventorySlot_UI clickedUISlot)
    {
        // Geklikte slot heeft een item en het mouse object heeft geen item - pak item op 
        if (clickedUISlot.AssignedInventorySlot.ItemData != null && mouseInventoryItem.AssignedInventorySlot.ItemData == null)
        {
            // is de speler shift aan het indrukken - split de stack
            mouseInventoryItem.UpdateMouseSlot(clickedUISlot.AssignedInventorySlot);
            clickedUISlot.ClearSlot();
            Debug.Log("True");
            return;
        }

        // Geklikte slot heeft geen item maar mouse object wel plaats mouse object item in slot
        if (clickedUISlot.AssignedInventorySlot.ItemData == null && mouseInventoryItem.AssignedInventorySlot.ItemData != null)
        {// dit is nooit true 
            Debug.Log("dsasadsadsadasd");
            clickedUISlot.AssignedInventorySlot.AssignItem(mouseInventoryItem.AssignedInventorySlot);
            clickedUISlot.UpdateUISlot();

            mouseInventoryItem.ClearSlot();
        }

            // Beide slots hebben een item - check 
            // Allebei items hetzelfde combineer ze
            // passen de items in de mouse object op de geselecteerde de stack - pak van mouse object



                // Beide niet hetzelfde dan wissel je ze


                // if (clickedSlot.AssignedInventorySlot.ItemData.GetType() == typeof(FoodItem))
                // {
                //     FoodItem eating = (FoodItem)clickedSlot.AssignedInventorySlot.ItemData;
                //     FoodSystemPlayer.AddFood(eating.FoodAmount, eating.WaterAmount);
                //     clickedSlot.AssignedInventorySlot.ClearSlot();
                //     clickedSlot.AssignedInventorySlot.UpdateInventorySlot(clickedSlot.AssignedInventorySlot.ItemData, clickedSlot.AssignedInventorySlot.StackSize);
                //     clickedSlot.UpdateUISlot();
                // }
    }
}

