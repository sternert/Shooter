using UnityEngine;
using System;

[Serializable]
public class LimitsValues
{
    public float XMin, XMax, YMin, YMax;
}

[Serializable]
public class Limits
{
    public GameObject limitsObject; // Must be object with Box Collider 2D

    // Get limits in a float[ x min, x max, y min, y max]
    public LimitsValues GetLimits()
    {
        var limits = new LimitsValues();
        var collider = limitsObject.GetComponent<BoxCollider2D>();
        if (collider != null)
        {
            limits.XMin = collider.bounds.min.x;
            limits.XMax = collider.bounds.max.x;
            limits.YMin = collider.bounds.min.y;
            limits.YMax = collider.bounds.max.y;
        }
        return limits;
    }
}