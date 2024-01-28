using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentAi : MonoBehaviour
{
    public List<Transform> waypoints;
    protected NavMeshAgent navMeshAgent;
    [SerializeField] protected int currentWaypointIndex = 0;
    [SerializeField] protected float distanceToWaypoint;
    [SerializeField] protected Animator animator;
    [SerializeField] protected Transform intialTransform;


    public bool distracted = false;

    // Start is called before the first frame update
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        intialTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!distracted)
        {
            Walking();
        }

    }

    public virtual void Walking()
    {

    }



    public void Distract(Transform distractLocation, float time)
    {
        distracted = true;
        navMeshAgent.SetDestination(distractLocation.position);
        StartCoroutine(DistractTimer());
    }

    private IEnumerator DistractTimer()
    {
        yield return new WaitForSeconds(5.0f);
        navMeshAgent.SetDestination(intialTransform.position);
    }

        public void OnFootstep()
    {

    }
}
