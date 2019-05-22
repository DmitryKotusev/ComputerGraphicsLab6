using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class Line
{
    public Transform point1;
    public Transform point2;

    public Line()
    {

    }

    public Line(Transform point1, Transform point2)
    {
        this.point1 = point1;
        this.point2 = point2;
    }
}
