using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericDoor : MonoBehaviour, IInteractable
{
    public Transform OpenDoor;
    public Transform ClosedDoor;
    public bool open;
    private bool opening;

    public void Interact()
    {
        if (opening)
        {

        }
        if(!open)
        {
            transform.rotation = Quaternion.Slerp(OpenDoor.rotation, ClosedDoor.rotation, 1f);
            transform.position = Vector3.Slerp(OpenDoor.position, ClosedDoor.position, 1f); 
        }
        else if (open)
        {
            transform.rotation = Quaternion.Slerp(ClosedDoor.rotation, OpenDoor.rotation, 1f);
            transform.position = Vector3.Slerp(ClosedDoor.position, OpenDoor.position, 1f);
        }
    }
}
