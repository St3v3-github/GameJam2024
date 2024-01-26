using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PlayerInteraction : MonoBehaviour
{
    public Inventory playerInventory;

    public float raycastDistance = 3f;
    public KeyCode pickupKey = KeyCode.E;

    void Start()
    {

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
    }

    public void PickUpItem(PrankItem item)
    {
        playerInventory.AddItem(item);
    }
}
