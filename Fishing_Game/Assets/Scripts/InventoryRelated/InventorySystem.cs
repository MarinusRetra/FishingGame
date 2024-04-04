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
        get { return inventorySlots.Count; }
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

    public bool AddToInventory(InventoryItemData itemIn, int amountOfItem)
    {
        if (CointainsItem(itemIn, out List<InventorySlot> invSlot)) // kijkt of het item dat toegevoegd gaat worden al in de inventory zit
        {
            foreach (InventorySlot slot in invSlot)
            {
                if (slot.RoomLeftInStack(amountOfItem))// als er genoeg ruimte over is in de stack van de current slot voeg item toe aan dat slot  zo niet check volgende slot met matchende item
                {
                //voeg hier later toe als 4 items probeert toevoegen aan een slot met 3/5 doe twee in dat slot en ga naar volgende slot met matchende items en doe hetzelfde
                    slot.AddToStack(amountOfItem);
                    OnInventorySlotChanged?.Invoke(slot);
                    return true;
                }
            }
        }

        if (HasFreeSlot(out InventorySlot FreeSlot)) // pakt de eert vrije slot
        {
            FreeSlot.UpdateInventorySlot(itemIn,amountOfItem);
            OnInventorySlotChanged?.Invoke(FreeSlot);
            return true;
        } 

        return false;
    }
    /// <summary>
    /// Return true als het item dat toegevoegd wilt worden all in je inventory zit ander return false
    /// </summary>
    /// <param name="itemIn">Item dat je probeert toe te voegen</param>
    /// <param name="invSlotOut">een lijst met InventorySlots</param>
    /// <returns></returns>
    public bool CointainsItem(InventoryItemData itemIn, out List<InventorySlot> invSlotOut)
    {
    //gaat door invetorySlots heen, als de slot die checheckt wordt zijn ItemData als hetzelfde item dat toegevoegd wordt voeg slot toe aan list
        invSlotOut = inventorySlots.Where(i => i.ItemData == itemIn).ToList();

        return invSlotOut == null ? false : true;
    }

    public bool HasFreeSlot(out InventorySlot FreeSlot)
    {
        FreeSlot = InventorySlots.FirstOrDefault(i => i.ItemData == null); // pakt de eerste inventory slot die een null waarde heeft
        return FreeSlot == null ? true : false;

    }
}
