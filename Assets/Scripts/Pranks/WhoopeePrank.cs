using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhoopeePrank : Prank
{
    public Transform whoopeeLocation;
    public GameObject whoopee;
    public override void startPrank()
    {
        Debug.Log("WHOOPeeED");
        GameObject obj = Instantiate(whoopee, whoopeeLocation);
    }
}
