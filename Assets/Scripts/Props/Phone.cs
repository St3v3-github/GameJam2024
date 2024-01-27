using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour, IInteractable
{
    private PrankManager manager;
    public PrankEvents distractEvent;

    void Start()
    {
        manager = FindObjectOfType<PrankManager>();
    }

    public void Interact()
    {
        manager.CurrentNPC.Distract();
        distractEvent.completed = true;
    }
}
