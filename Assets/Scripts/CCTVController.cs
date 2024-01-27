using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CCTVController : MonoBehaviour
{

    [SerializeField]
    public GameObject[] UI;
    public GameObject[] Cams;
    private int camindex = 0;
    // Start is called before the first frame update
    void Start()
    {
        UI[camindex].SetActive(true);
        Cams[camindex].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            camindex++; 
            if (camindex >= UI.Length)
            {
                camindex =  0; 
            }
            ResetPrio();
            UI[camindex].SetActive(true);
            Cams[camindex].SetActive(true); 
            Debug.Log(camindex); 

        }
    }

    void ResetPrio()
    {
        foreach (var GO in UI)
        {
            GO.SetActive(false);
            
        }

        foreach(var cams in Cams)
        {
            cams.SetActive(false); 
        }
    }
}
