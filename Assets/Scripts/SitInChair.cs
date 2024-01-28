using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SitInChair : MonoBehaviour, IInteractable
{
    private GameObject player;
    private Transform chairTransform;

    void Start()
    {
        player = GameObject.Find("PlayerCharacter");
        chairTransform = this.gameObject.transform;
    }

    public void Interact()
    {
        player.GetComponent<PlayerInteraction>().SetSitDown();

        player.transform.position = chairTransform.position;
        player.transform.rotation = chairTransform.rotation;
        player.transform.Rotate(0, 180, 0);
        player.GetComponent<CharacterController>().enabled = false;
        player.GetComponent<Animator>().enabled = false;
    }
}

