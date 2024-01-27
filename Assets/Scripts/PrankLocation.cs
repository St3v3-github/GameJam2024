using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PrankLocation : MonoBehaviour, IPrankable
{
    public List<PrankItem> requiredItems;
    public List<PrankEvents> requiredEvents;
    public bool completed = false;

    public void Prank(Inventory inv)
    {
        if (CheckPrerequisites(inv))
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool CheckPrerequisites(Inventory inv)
    {
        bool ItemCheck = CheckItemList(inv.items);
        bool EventCheck = CheckEventList();
        if (ItemCheck && EventCheck)
        {
            return true;
        }
        return false;
    }
    bool CheckItemList(List<PrankItem> inv)
    {
        foreach (PrankItem requiredItem in requiredItems)
        {
            if (!inv.Contains(requiredItem))
            {
                return false;
            }
        }
        return true;
    }

    bool CheckEventList()
    {
        foreach (PrankEvents requiredEvent in requiredEvents)
        {
            if (requiredEvent.completed == false)
            {
                return false;
            }
        }
        return true;
    }
}

