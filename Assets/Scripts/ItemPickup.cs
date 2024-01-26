using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour, IPickupable
{
    public PrankItem item;
    public void Pickup()
    {
        Destroy(gameObject);
    }
}
