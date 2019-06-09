using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePointController : MonoBehaviour
{
    public float speed = 1.0f;
    public float damping = 3.0f;

    private Transform tr;
    private Transform[] points;
    private int nextIndex = 1;
    
    void Start()
    {
        tr = GetComponent<Transform>();
        GameObject WayPointGroup = transform.parent.Find("WayPointGroup").gameObject;
        points = WayPointGroup.GetComponentsInChildren<Transform>();
    }
    
    void Update()
    {
        MoveWayPoint();
    }

    void MoveWayPoint()
    {
        Vector2 direction = points[nextIndex].position - tr.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));

        tr.rotation = Quaternion.Slerp(tr.rotation, q, Time.deltaTime * damping);
        tr.Translate(Vector2.right * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        try
        {
            if (other.CompareTag("WayPoint") && other.transform.parent.parent.Find(gameObject.name) != null)
            {
                if (++nextIndex >= points.Length)
                    nextIndex = 1;
            }
        }
        catch { }
    }
}
