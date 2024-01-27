using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitInChair : MonoBehaviour, IInteractable
{
    private GameObject player;

    private Transform savedPlayerPos;

    public void Interact()
    {
        Debug.Log("Hello");
    }
}

