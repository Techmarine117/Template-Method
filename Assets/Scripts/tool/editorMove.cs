using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class editorMove : MonoBehaviour
{
    public Editorwaypoint path;

    public int CurrentWayPoint;

    public float moveSpeed;
    private float distanceToReach = 1.0f;
    public float rotationspeed = 5.0f;
    public string pathName;

    Vector3 lastPosition;
    Vector3 currentPosition;
   
    void Start()
    {
        path = GameObject.Find(pathName).GetComponent<Editorwaypoint>();
        lastPosition = transform.position;
    }

  
    void Update()
    {
        float distance = Vector3.Distance(path.waypoint_objs[CurrentWayPoint].position, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, path.waypoint_objs[CurrentWayPoint].position, Time.deltaTime * moveSpeed);

        Quaternion rotation = Quaternion.LookRotation(path.waypoint_objs[CurrentWayPoint].position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationspeed);

        if(distance <= distanceToReach)
        {
            CurrentWayPoint++;
        }


        if(CurrentWayPoint >= path.waypoint_objs.Count)
        {
            CurrentWayPoint = 0;
        }
    }
}
