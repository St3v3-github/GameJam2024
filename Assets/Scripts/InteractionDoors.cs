using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDoors : MonoBehaviour
{
    public bool InRange;
    public bool Enabled;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (InRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {


                if (!Enabled)
                {
                    animator.Play("Opening");
                    Enabled = true;
                }

                else
                {
                    animator.Play("Closing");
                    Enabled = false;
                }

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InRange = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InRange = false;

        }
    }
}