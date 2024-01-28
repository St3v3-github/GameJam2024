using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour, IInteractable
{
    private PrankManager manager;
    public List<PrankEvents> distractEvents;

    void Start()
    {
        manager = FindObjectOfType<PrankManager>();
    }

    public void Interact()
    {
        manager.CurrentNPC[0].Distract(transform, 8f);
        distractEvents[0].completed = true;
    }
}
