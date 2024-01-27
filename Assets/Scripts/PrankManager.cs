using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrankManager : MonoBehaviour
{
    enum Prank {Test, Whoopie, LockinIn, Chair, Shock, Poison, Burn, Murder};

    //Items
    GameObject waterBottle;
    GameObject whoopieCushion;
    GameObject closetKey;
    GameObject ScrewDriver;
    //Not sure what to have as the shock item yet
    GameObject shockItem;
    GameObject poison;
    GameObject lighter;
    GameObject knife;

    //Locations

    //PrankPeople

    Prank currentPrank;
    GameObject currentItem;

    // Start is called before the first frame update
    void Start()
    {
        currentPrank = Prank.Test;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentPrank == Prank.Test)
        {
            currentItem = waterBottle;
        }
    }
}
