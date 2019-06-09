using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointTrack : MonoBehaviour
{
    public Color lineColor = Color.yellow;
    private Transform[] points;

    private void OnDrawGizmos()
    {
        Gizmos.color = lineColor;
        points = GetComponentsInChildren<Transform>();

        int nextIndex = 1;

        Vector2 currpos = points[nextIndex].position;
        Vector2 nextpos;

        for (int i = 0; i < points.Length; i++)
        {
            if (++nextIndex >= points.Length)
                nextpos = points[i].position;
            else
                nextpos = points[nextIndex].position;

            Gizmos.DrawLine(currpos, nextpos);

            currpos = nextpos;
        }
    }
}
