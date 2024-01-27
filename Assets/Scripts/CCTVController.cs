using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CCTVController : MonoBehaviour
{

    [SerializeField]
    public GameObject[] cams;
    private int camindex = 0;
    // Start is called before the first frame update
    void Start()
    {
        cams[camindex].SetActive(true);  
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            camindex++; 
            if (camindex >= cams.Length)
            {
                camindex =  0; 
            }
            ResetPrio();
            cams[camindex].SetActive(true); 
            Debug.Log(camindex); 

        }
    }

    void ResetPrio()
    {
        foreach (var cams in cams)
        {
            cams.SetActive(false); 
        }
    }
}
