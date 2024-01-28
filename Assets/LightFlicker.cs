using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light myLight;
    float interval = 7;
    float timer;
    // Start is called before the first frame update
    void Start()
    {


        
    }
    void Update()
        {
            timer += Time.deltaTime;
            if (timer > interval)
            {
                myLight.enabled = !myLight.enabled;
                interval = Random.Range(0f, 1f);
                timer = 0;
            }
        }
}



    
   

