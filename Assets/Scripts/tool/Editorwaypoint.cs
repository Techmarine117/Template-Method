using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Editorwaypoint : MonoBehaviour
{
    public Color waypointColor = Color.blue;
    public List<Transform> waypoint_objs = new List<Transform>();
    Transform[] Array;

    private void OnDrawGizmos()
    {
        Gizmos.color = waypointColor;
        Array = GetComponentsInChildren<Transform>();
        waypoint_objs.Clear();

        foreach(Transform waypoint_obj in Array)
        {
            if(waypoint_obj != this.transform)
            {
                waypoint_objs.Add(waypoint_obj);
            }
        }

      for(int i = 0; i < waypoint_objs.Count; i++)
        {
            Vector3 position = waypoint_objs[i].position;
            if(i > 0)
            {
                Vector3 previousObjs = waypoint_objs[i - 1].position;
                Gizmos.DrawLine(previousObjs,position);
                Gizmos.DrawWireSphere(position, 0.3f);
            }
        }
    }
}
