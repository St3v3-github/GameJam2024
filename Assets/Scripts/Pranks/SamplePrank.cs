using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamplePrank : Prank
{

    public override void startPrank()
    {
        Debug.Log("PRANKED");
        this.gameObject.transform.localScale *= 100f;
    }
}
