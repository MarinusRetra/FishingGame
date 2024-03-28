using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

[System.Serializable] // voor saving naar een JSON
public class InventorySystem
{
    [SerializeField] private List<InventorySlot> inventorySlots;

    public List<InventorySlot> InventorySlots 
    { // readonly voor inventorySlots
        get { return inventorySlots; }
    }
    public int InventorySize 
    { // Aantal inventory slots
        get { return InventorySlots.Count; }
    }

    public UnityAction<InventorySlot> OnInventorySlotChanged;

    public InventorySystem(int Size) // maakt het aantal inventory slots op basis van ingevoerde Size
    {
     inventorySlots = new List<InventorySlot>(Size);
     for (int i = 0; i < Size;  i++)
     {
         inventorySlots.Add(new InventorySlot());
     }

    }

    public bool AddToInvetory(InventoryItemData itemIn, int amountOfItem)
    {
        InventorySlots[0] = new InventorySlot(itemIn, amountOfItem);
        return true; 
    }

}
