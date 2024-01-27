using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentAi : MonoBehaviour
{
    public List<Transform> waypoints;
    private NavMeshAgent navMeshAgent;
    [SerializeField] private int currentWaypointIndex = 0;
    [SerializeField] private float distanceToWaypoint;
    [SerializeField] private Animator animator;

    // Start is called before the first frame update
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update()
    {
        Walking();
    }

    private void Walking()
    {
        if (waypoints.Count == 0.0f)
        {
            return;
        }

        distanceToWaypoint = Vector3.Distance(waypoints[currentWaypointIndex].position, transform.position);

        if (distanceToWaypoint <= 1.0f) 
        {
            StartCoroutine(WalkingDelay());
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
        }

        navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
    }

    private IEnumerator WalkingDelay()
    {
        navMeshAgent.speed = 0.0f;
        animator.SetBool("IsIdle", true);
        animator.SetBool("IsWalking", false);
        yield return new WaitForSeconds(5.5f);
        animator.SetBool("IsWalking", true);
        animator.SetBool("IsIdle", false);
        navMeshAgent.speed = 2.0f;
    }
}
