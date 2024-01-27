using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class Roaming : MonoBehaviour
{
    public NavMeshAgent NPC;
    public List<Vector3> waypoints;
    public Vector3 CurrentTarget;
    public int currentindex = 1;
    

    private int i; 

    public enum State
        {
            prank1

        }

    private State currentstate = State.prank1; 
    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {

       switch (currentstate)
        {
            case State.prank1:
                Prank1();
                break; 
        }
  

    }

    private IEnumerator NextWaypointDelay()
    {
        Debug.Log("Hit");
        yield return new WaitForSecondsRealtime(5);
       

    }
    void Prank1()
    {
    

        if (waypoints.Count > 0 && waypoints[0] != null)
        {
            CurrentTarget = waypoints[currentindex];
            NPC.SetDestination(CurrentTarget);

        }

        if(NPC.remainingDistance < 0.1)
        {
             CurrentTarget = waypoints[currentindex + 1];
             NPC.SetDestination(CurrentTarget);
                 
        }
    }
}

