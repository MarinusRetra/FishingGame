using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // nodig voor het opslaan in een JSON

public class InventorySlot
{
    [SerializeField] private InventoryItemData itemData; // het scriptable object met alle info over een item
    [SerializeField] private int stackSize; // de huidige stackSize van een item

    public InventoryItemData ItemData //readonly ItemData
    {
        get { return itemData; }
    }

    public int StackSize //readonly StackSize
    {
        get { return stackSize; }
    }

    public InventorySlot(InventoryItemData _ItemDataIn, int _amount)
    {
      itemData = _ItemDataIn;
      stackSize = _amount;
    }

    public InventorySlot() //leeg slot
    {
        ClearSlot();
    }

    public void UpdateInventorySlot(InventoryItemData _ItemDataIn, int _amount)
    {
        itemData = _ItemDataIn;
        stackSize = _amount;
    }

    public void ClearSlot()
    {
        itemData = null;
        stackSize = -1;
    }
    /// <summary>
    /// Rekent uit hoeveel items nog kunnen stacken op 1 slot. 12 toevoegen aan een slot met 5 items met een MaxStackSize van 15 voegt dus 10 items toe en laat de overige 2 zitten
    /// </summary>
    /// <param name="amountToAdd">Hoeveelheid die geprobeerd toegevoegd te worden aan inventory slot</param>
    /// <param name="AmountRemaining">De maximale stackSize - de StackSize in de slot</param>
    /// <returns></returns>
    public bool RoomLeftInStack(int amountToAdd, out int AmountRemaining)
    {
        AmountRemaining = ItemData.MaxStackSize - stackSize;
        return RoomLeftInStack(AmountRemaining);
    }

    /// <summary>
    /// zolang de hoeveelhied items in een slot + de items die je wilt toevoegen lager zijn dan de MaxStackSize return true anders return false
    /// </summary>
    /// <param name="amountToAdd">Hoeveelheid die geprobeerd toegevoegd te worden aan inventory slot</param>
    /// <returns></returns>
    public bool RoomLeftInStack(int amountToAdd)
    {
        if (stackSize + amountToAdd <= itemData.MaxStackSize)
        {
            return true;
        }
        else 
            return false;
    }


    public void AddToStack(int amount) //voeg item toe
    {
        stackSize += amount;
    }

    public void RemoveFromStack(int amount) //haal item weg
    {
        stackSize -= amount;
    }

}
