using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour, IInteractable
{
    PrankManager manager = FindObjectOfType<PrankManager>();

    public void Interact()
    {
        //manager.CurrentNPC.Distract();
    }
}
