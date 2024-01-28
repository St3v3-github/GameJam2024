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
    public Image popupImage;
    public TextMeshProUGUI popupText;

    private bool isSatDown = false;
    [SerializeField] private TextMeshProUGUI standUpText;
    private Transform savedPlayerPos;

    void Start()
    {

    }

    void Update()
    {
        //Stand Up
        StandUp();

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
                        AudioManager.instance.PlayOneShot(FMODEvents.instance.itemSound, this.transform.position);
                    }

                    //Pop up notifictation
                    popupImage.gameObject.SetActive(true);
                    popupText.gameObject.SetActive(true);
                    popupImage.sprite = item.Icon;
                    popupText.text = item.itemName;
                    StartCoroutine(timerCoroutine());
                }

                // InteractableObject
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    interactable.Interact();
                }

                // InteractableObject
                IPrankable prankable = hit.collider.GetComponent<IPrankable>();
                if (prankable != null)
                {
                    prankable.Prank(this.gameObject.GetComponent<Inventory>());
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
            IPrankable prankable = hitForText.collider.GetComponent<IPrankable>();
            if (pickupable != null)
            {
                interactText.text = "Press " + pickupKey.ToString() + " to Pickup " + hitForText.collider.GetComponent<ItemPickup>().item.itemName;
                interactText.gameObject.SetActive(true);

            }
            else if (interactable != null)
            {
                interactText.text = "Press " + pickupKey.ToString() + " to Interact";
                interactText.gameObject.SetActive(true);
            }
            else if (prankable != null)
            {
                if (hitForText.collider.GetComponent<PrankLocation>().CheckPrerequisites(this.gameObject.GetComponent<Inventory>()))
                {
                    interactText.text = "Press " + pickupKey.ToString() + " to Prank";
                    interactText.gameObject.SetActive(true);
                }
                else
                {
                    interactText.text = "Complete the steps to prank";
                    interactText.gameObject.SetActive(true);
                }
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
    }

    public void PickUpItem(PrankItem item)
    {
        playerInventory.AddItem(item);
    }

    private IEnumerator timerCoroutine()
    {

        yield return new WaitForSeconds(2f);
        popupText.text = "";
        popupImage.gameObject.SetActive(false);
        popupText.gameObject.SetActive(false);
    }

    public void SetSitDown()
    {
        isSatDown = true;
        standUpText.gameObject.SetActive(true);
    }

    private void StandUp()
    {
        if (isSatDown && Input.GetKeyDown(pickupKey))
        {
            //StandUp

            GetComponent<CharacterController>().enabled = true;
            GetComponent<Animator>().enabled = true;

            isSatDown=false;
            standUpText.gameObject.SetActive(false);
        }
    }
}