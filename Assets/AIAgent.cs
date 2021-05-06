using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAgent : MonoBehaviour
{
    public Transform[] Waypoints;
    public Transform player;
    public int index;
    public int speed;

    public float visionRange;
    public float hitRange;
    public float angleDifference;
    public float patrolRotation;

    // TO DO MOVE TO REGULAR AI
    public float tempTimer;
    public float seekTimer;
    public Vector3 lastKnownPosition;

    public bool PlayerSpotted = false;
    public Rigidbody rb;
    public Vector3 destination;
    private float distance;
    public bool isMelle = false;
    public float sensorLength;
    public float avoidMultiplier;
    public Vector3 avoidance;
    RaycastHit hit;
    public float sensorAngle;
    private void Start()
    {
    }


    void Update()
    {
        Move(Waypoints[index].position);
        if (Vector3.Distance(Waypoints[index].position, transform.position) < 0.5f) { index++; index %= Waypoints.Length; }
    }
    public void Move(Vector3 destination)
    {
        destination.y = transform.position.y;
        Vector3 direction = destination - this.transform.position;
        direction = direction.normalized;
        float halfLength = sensorLength *0.7f;
        if (Physics.Raycast(this.transform.position, direction, out hit, sensorLength))
        {
            avoidance = Vector3.Cross(Vector3.Cross(hit.normal,direction),-direction).normalized * avoidMultiplier;
            Debug.DrawLine(hit.point, hit.point + avoidance);
        }
        else if (Physics.Raycast(this.transform.position, Quaternion.AngleAxis(sensorAngle, transform.up) * direction, out hit, halfLength))
        {
            avoidance = Vector3.Cross(Vector3.Cross(hit.normal, direction), -direction).normalized * avoidMultiplier;
            Debug.DrawLine(hit.point, hit.point + avoidance);
        }
        else if (Physics.Raycast(this.transform.position, Quaternion.AngleAxis(-sensorAngle, transform.up) * direction, out hit, halfLength))
        {
            avoidance = Vector3.Cross(Vector3.Cross(hit.normal, direction), -direction).normalized * avoidMultiplier;
            Debug.DrawLine(hit.point, hit.point + avoidance);
        }
        Debug.DrawLine(transform.position, transform.position + (transform.forward * sensorLength), Color.cyan);
        Debug.DrawLine(transform.position, transform.position + (Quaternion.AngleAxis(sensorAngle, transform.up) * transform.forward * halfLength), Color.cyan);
        Debug.DrawLine(transform.position, transform.position + (Quaternion.AngleAxis(-sensorAngle, transform.up) * transform.forward * halfLength), Color.cyan);

        
        direction += avoidance;
        avoidance = Vector3.MoveTowards(avoidance,Vector3.zero, 2 *Time.deltaTime);
        //Quaternion rotTarget = Quaternion.LookRotation(direction);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, rotTarget, 10);

        rb.AddForce(direction * speed);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, speed);
        transform.rotation = Quaternion.LookRotation( rb.velocity);
    }
}
