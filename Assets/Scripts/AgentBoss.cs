using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentBoss : AgentAi
{
    public GameObject Phone;


    public override void Walking()
    {
        Debug.Log("running");

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
}
