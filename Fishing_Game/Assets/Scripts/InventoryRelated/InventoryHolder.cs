using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]

public class InventoryHolder : MonoBehaviour
{/// <summary>
/// Aantal invetorySlots van dit object
/// </summary>
    [SerializeField] private int inventorySize;
    /// <summary>
    /// inventorySystem heeft de inventory size en een list<InventorySlots> als toegankelijke variabelen in zich
    /// </summary>
    [SerializeField] protected InventorySystem inventorySystem; 

    public InventorySystem InventorySystem // readonly invetorySystem
    {
        get { return inventorySystem; }
    }

    public static UnityAction<InventorySystem> OnDynamicInventoryDisplayRequested;


    private void Awake()
    {
        inventorySystem = new InventorySystem(inventorySize); 
    }


}
