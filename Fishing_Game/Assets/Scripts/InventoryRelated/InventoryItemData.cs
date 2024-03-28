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
}
