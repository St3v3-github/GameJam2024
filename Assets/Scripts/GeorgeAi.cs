using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GeorgeAi : MonoBehaviour
{
    public List<Transform> waypoints;
    private NavMeshAgent navMeshAgent;
    [SerializeField] private Animator animator;
    [SerializeField] private int currentWaypointIndex = 0;
    [SerializeField] private float distanceToWaypoint;
    [SerializeField] private bool distracted = false;
    [SerializeField] private bool isSitting = false;


    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.enabled = false;
    }

    private void Update()
    {
        Walking();
    }

    private void Walking()
    {
        if (Distract(true))
        {
            navMeshAgent.enabled = true;


            if (waypoints.Count == 0.0f)
            {
                return;
            }

            distanceToWaypoint = Vector3.Distance(waypoints[currentWaypointIndex].position, transform.position);

            if (distanceToWaypoint <= 1.1f)
            {
                animator.SetBool("IsWalking", true);
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
            }

            if (currentWaypointIndex == 0 && isSitting)
            {
                distracted = false;
                animator.SetTrigger("Typing");
                animator.SetBool("IsWalking", false);
                navMeshAgent.enabled = false;
            }

            if (currentWaypointIndex == 5)
            {
                StartCoroutine(WaitAtFrontDesk());
                isSitting = true;
            }

        }

        navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
        
    }

    private IEnumerator WaitAtFrontDesk()
    {
        animator.SetBool("IsIdle", true);
        animator.SetBool("IsWalking", false);
        navMeshAgent.speed = 0.0f;
        yield return new WaitForSeconds(5.0f);
        navMeshAgent.speed = 2.0f;
        animator.SetBool("IsIdle", false);
        animator.SetBool("IsWalking", true);
    }

    public bool Distract(bool isDistracted)
    {
        isDistracted = distracted;

        return isDistracted;
    }

    public void OnFootstep()
    {

    }
}
