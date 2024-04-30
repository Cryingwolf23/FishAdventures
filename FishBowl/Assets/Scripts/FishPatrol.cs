using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishPatrol : MonoBehaviour
{
    //public Transform[] waypoints;
    public Vector2[] waypoints;
    private int currentWaypointIndex;
    [SerializeField] private float speed = 2f;

    
    private void Update()
    {


        Vector2 wp = waypoints[currentWaypointIndex];

        if (transform.position.x > wp.x)
        {
            transform.rotation = Quaternion.identity;

        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (Vector2.Distance(transform.position, wp)< 1.0f)
        {
           currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }

        else
        {
            transform.position = Vector2.MoveTowards(transform.position, wp, speed * Time.deltaTime);

            




        }
    }
}
