using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "InventorySystem/InventoryItem") ]
public class InventoryItemData : ScriptableObject
{
    public int ID;
    public string DisplayName;
    [TextArea( 4,4)] //Zorgt dat ik de item description in de inspector kan bekijken.
    public string Description;
    public Sprite Icon;
    public int MaxStackSize;
    protected bool sellable = true;
}

[CreateAssetMenu(menuName = "InventorySystem/FoodItem")]
public class FoodItem : InventoryItemData
{
    public int FoodAmount;
    public int WaterAmount;
}

[CreateAssetMenu(menuName = "InventorySystem/Equipment")]
public class Equipment : InventoryItemData
{
    public int durability;
    public Equipment()
    {
        sellable = false;
    }
    
}
