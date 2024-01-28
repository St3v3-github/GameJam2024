using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    public List<PrankItem> items = new List<PrankItem>();


    public void AddItem(PrankItem item)
    {
        // Adds Item from Inventory
        PrankItem existingItem = items.Find(i => i == item);

        items.Add(item);

        foreach (PrankItem prank in items)
        {
            Debug.Log(prank.itemName);
        }
    }

    public bool searchInventory(PrankItem item)
    {
        foreach (PrankItem itemInInv in items)
        {
            if (itemInInv == item)
            {
                return true;
            }
        }
        return false;
    }
}
