﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    public GameObject linesContainer;
    public GameObject linePrefab;

    public Line[] lines;
    public GameObject[] points;

    void DrawLines()
    {
        foreach (Line line in lines)
        {
            Vector3 globalRespawnPosition = (line.point1.position + line.point2.position) / 2f;
            GameObject newLine = Instantiate(linePrefab, globalRespawnPosition, linePrefab.transform.rotation, linesContainer.transform);
            LineRenderer lineRenderer = newLine.GetComponent<LineRenderer>();
            lineRenderer.positionCount = 2;
            lineRenderer.SetPositions(new Vector3[] { newLine.transform.InverseTransformPoint(line.point1.position),
                newLine.transform.InverseTransformPoint(line.point2.position) });
        }
    }

    private void Start()
    {
        DrawLines();
    }
}
