using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSnap : MonoBehaviour
{
    private Transform[] points;

    private void OnDrawGizmos()
    {
        points = GetComponentsInChildren<Transform>();

        foreach (var pointtrans in points)
        {
            pointtrans.position = new Vector2(Mathf.Round(pointtrans.position.x), Mathf.Round(pointtrans.position.y));
        }
    }
}
