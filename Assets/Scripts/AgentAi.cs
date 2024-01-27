using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentAi : MonoBehaviour
{
    public List<Transform> waypoints;
    private NavMeshAgent navMeshAgent;
    //[SerializeField] private float speed = 2.0f;
    [SerializeField] private int currentWaypointIndex = 0;

    // Start is called before the first frame update
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update()
    {
        /*Vector3 destination = waypoints[currentWaypointIndex].transform.position;
        Vector3 newPosition = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
        transform.position = newPosition;

        float distance = Vector3.Distance(transform.position, destination);

        if (distance <= 0.05f) 
        {
            currentWaypointIndex++;
        }

        if (currentWaypointIndex == 3)
        {
            currentWaypointIndex = 0;
        }*/

        Walking();
    }

    private void Walking()
    {
        if (waypoints.Count == 0.0f)
        {
            return;
        }

        float distanceToWaypoint = Vector3.Distance(waypoints[currentWaypointIndex].position, transform.position);

        if (distanceToWaypoint <= 3.0f) 
        {
            currentWaypointIndex = (currentWaypointIndex+ 1) % waypoints.Count;
        }

        navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
    }
}
