using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentAi : MonoBehaviour
{
    public List<Transform> waypoints;
    public bool sitting;
    protected NavMeshAgent navMeshAgent;
    [SerializeField] protected int currentWaypointIndex = 0;
    [SerializeField] protected float distanceToWaypoint;
    [SerializeField] protected Animator animator;
    [SerializeField] protected Vector3 intialPos;


    public bool distracted = false;
    public bool returning = false;

    // Start is called before the first frame update
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        intialPos = transform.position;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (!distracted)
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
        else
        {
            DistractCheck();
        }

    }

    public virtual void Walking()
    {

    }
    public virtual void Sitting()
    {

    }



    public void Distract(Transform distractLocation, float time)
    {
        distracted = true;
        animator.SetBool("IsWalking", true);
        navMeshAgent.SetDestination(distractLocation.position);
        StartCoroutine(DistractTimer(time));
    }

    public void DistractCheck()
    {
        if (returning)
        {
            float distance = Vector3.Distance(intialPos, transform.position);
            if (distance <= 1.1f)
            {
                animator.SetBool("IsWalking", false);
                distracted = false;
                returning = false;
                StartCoroutine(angryTimer());
            }
        }
    }

    private IEnumerator DistractTimer(float time)
    {
        yield return new WaitForSeconds(time);
        returning = true;
        navMeshAgent.SetDestination(intialPos);
    }

    private IEnumerator angryTimer()
    {
        yield return new WaitForSeconds(2f);
    }

    public void OnFootstep()
    {

    }
}
