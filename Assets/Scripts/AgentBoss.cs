using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentBoss : AgentAi
{
    public GameObject Phone;
    public Transform itemTransform;
    private PrankItem confiscatedItem;
    private bool toOffice = false;

    public override void Update()
    {
        if (!distracted && !toOffice)
        {
            if (!sitting)
            {
                Walking();
            }
            else
            {
                Sitting();
            }

        }

        if (toOffice)
        {
            WalkingtoOffice();
        }
        

    }

    public override void Walking()
    {

        if (waypoints.Count == 0.0f) { return; }
        //if (distracted) { return; }

        distanceToWaypoint = Vector3.Distance(waypoints[currentWaypointIndex].position, transform.position);

        if (distanceToWaypoint <= 1.1f)
        {
            StartCoroutine(TalkingOnPhoneAnim());
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
        }
        /*else if (distanceToWaypoint <= 1.0f && currentWaypointIndex == 0)
        {
            StartCoroutine(TalkingOnPhoneAnim());
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
        }*/

        navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
    }

    public void WalkingtoOffice()
    {
        float distance = Vector3.Distance(waypoints[currentWaypointIndex].position, transform.position);
        if (distance <= 1.1f)
        {
            GameObject obj = Instantiate(confiscatedItem.prefab, itemTransform.position, Quaternion.identity);
            toOffice = false;
        }
    }
    private IEnumerator TalkingOnPhoneAnim()
    {
        Phone.SetActive(true);
        navMeshAgent.speed = 0.0f;
        animator.SetTrigger("TalkingOnPhone");
        animator.SetBool("IsWalking", false);
        yield return new WaitForSeconds(10.0f);
        animator.SetTrigger("HangingCall");
        yield return new WaitForSeconds(5.0f);
        Phone.SetActive(false);
        animator.SetBool("IsWalking", true);
        navMeshAgent.speed = 2.0f;
    }

    public void Caught(PrankItem takenItem)
    {
        confiscatedItem = takenItem;
        navMeshAgent.SetDestination(intialPos);
        toOffice = true;
    }
}
