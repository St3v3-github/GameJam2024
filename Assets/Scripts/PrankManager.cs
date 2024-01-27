using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PrankManager : MonoBehaviour
{
    public List<PrankLocation> PrankList;
    public int index = 0;
    public int hintIndex = 0;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        PrankList[index].active = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 60f)
        {
            if (hintIndex > 3)
            {
                hintIndex += 1;
            }
        }
    }

    public void CompletePrank()
    {
        index++;
        PrankList[index].active = true;
        hintIndex = 0;
    }

    public void StepPrank()
    {

    }
}
