using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class PlayerInteraction : MonoBehaviour
{
    public Inventory playerInventory;

    public float raycastDistance = 3f;
    public KeyCode pickupKey = KeyCode.E;
    public TextMeshProUGUI interactText;

    [SerializeField] GameObject dialogueMangerObject;
    private DialogueManager dialogueManagerScript;

    void Start()
    {
        dialogueManagerScript = dialogueMangerObject.GetComponent<DialogueManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(pickupKey))
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, raycastDistance))
            {
                // Pickup able object
                IPickupable pickupable = hit.collider.GetComponent<IPickupable>();
                if (pickupable != null)
                {
                    pickupable.Pickup();

                    PrankItem item = hit.collider.GetComponent<ItemPickup>().item;
                    if (item != null)
                    {
                        PickUpItem(item);
                    }
                }

                // InteractableObject
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    interactable.Interact();
                }

            }
        }

        // Check for the raycast hit without pressing the key to show the interaction text
        Ray rayForText = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hitForText;

        if (Physics.Raycast(rayForText, out hitForText, raycastDistance))
        {
            // Check if the hit object has a script with the ItemPickup component
            IPickupable pickupable = hitForText.collider.GetComponent<IPickupable>();
            IInteractable interactable = hitForText.collider.GetComponent<IInteractable>();
            if (pickupable != null || interactable != null)
            {
                // Display the interaction text
                interactText.text = "Press " + pickupKey.ToString() + " to Interact";
                interactText.gameObject.SetActive(true);
            }
            else
            {
                // Hide the interaction text if not aiming at an item
                interactText.gameObject.SetActive(false);
            }
        }
        else
        {
            // Hide the interaction text if not aiming at anything
            interactText.gameObject.SetActive(false);
        }

        //Close Dialogue
        if(Input.GetKey("Q")) 
        {
            dialogueManagerScript.HideText();
        }
    }

    public void PickUpItem(PrankItem item)
    {
        playerInventory.AddItem(item);
    }
}
