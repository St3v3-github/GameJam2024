using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSteve : AgentAi
{
    [SerializeField] private Transform sickArea;
    public override void Walking()
    {
        if (waypoints.Count == 0.0f) { return; }
        //if (distracted) { return; }

        Distract(sickArea, 5.0f);

        distanceToWaypoint = Vector3.Distance(waypoints[currentWaypointIndex].position, transform.position);
        if (distanceToWaypoint <= 1.1f)
        {
            StartCoroutine(StandingStill());
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
        }

        navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
    }

    private IEnumerator StandingStill()
    {
        navMeshAgent.speed = 0.0f;
        animator.SetBool("IsIdle", true);
        animator.SetBool("IsWalking", false);
        yield return new WaitForSeconds(5.0f);
        animator.SetBool("IsIdle", false);
        animator.SetBool("IsWalking", true);
        navMeshAgent.speed = 2.0f;
    }
}
