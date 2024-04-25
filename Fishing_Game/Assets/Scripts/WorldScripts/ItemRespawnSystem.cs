using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemRespawnSystem
{   
    /// <summary>
    /// Gaat over alle GameObjects in HarvestedItems en zet 50% van de tijd het gecheckte GameObject aan
    /// </summary>
    public static void RespawnRandomItems()
    {
        for (int i = PickupInteractable.HarvestedItems.Count - 1; i >= 0; i--)
        {
            GameObject Object = PickupInteractable.HarvestedItems[i];
            if (Random.Range(0, 2) == 1) // 50% van de tijd wordt het object aangezet een verwijderd uit HarvestedItems
            {
                Object.SetActive(true);
                PickupInteractable.HarvestedItems.RemoveAt(i);
                //RespawnRandomItems();
            }
        }
    }
}
