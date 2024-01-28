using System.Collections;
using System.Collections.Generic;

using UnityEngine;


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
}
