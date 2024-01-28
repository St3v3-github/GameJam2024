using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIHide : MonoBehaviour
{
    bool Enabled;
    public GameObject UI; 
    // Start is called before the first frame update
    void Start()
    {
        Enabled = true; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {


            if (!Enabled)
            {
                UI.SetActive(true);
                Enabled = true;
            }

            else
            {
                UI.SetActive(false); 
                Enabled = false;
            }

        }
    }
}
