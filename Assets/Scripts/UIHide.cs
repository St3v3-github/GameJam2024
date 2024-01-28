using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHide : MonoBehaviour
{
    public GameObject UI;
    bool Enabled;
    // Start is called before the first frame update
    void Start()
    {
        
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
