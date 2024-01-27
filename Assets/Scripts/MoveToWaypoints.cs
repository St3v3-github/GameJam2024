using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToWaypoints : MonoBehaviour
{
    public List<GameObject> waypoints;
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private int index = 0;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 destination = waypoints[index].transform.position;
        Vector3 newPosition = Vector3.MoveTowards(transform.position, waypoints[index].transform.position, speed * Time.deltaTime);
        transform.position = newPosition;

        float distance = Vector3.Distance(transform.position, destination);

        if (distance <= 0.05f) 
        {
            index++;
        }

        if (index == 3)
        {
            index = 0;
        }
    }
}
