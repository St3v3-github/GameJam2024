using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitInChair : MonoBehaviour, IInteractable
{
    private GameObject player;
    private Transform chairTransform;
    private Transform savedPlayerPos;


    void Start()
    {
        player = GameObject.Find("PlayerCharacter");
        chairTransform = this.gameObject.transform;
    }

    public void Interact()
    {
        //Debug.Log("Hi");

        savedPlayerPos = player.transform;

        player.transform.position = chairTransform.position;
        player.transform.rotation = chairTransform.rotation;
        player.transform.Rotate(0, 180, 0);
        //player.GetComponent<ThirdPersonController>().enabled = false;
        player.GetComponent<CharacterController>().enabled = false;
    }
}

