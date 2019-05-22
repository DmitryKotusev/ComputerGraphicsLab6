using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projector : MonoBehaviour
{
    public GameObject targerObject;
    public Material verticesMaterial;
    public GameObject linePrefab;
    public GameObject pointsContainer;
    public GameObject linesContainer;
    public float pointsScaleCoefficient = 0.1f;
    /// <summary>
    /// First - original,
    /// Second - its projected analogue
    /// </summary>
    Dictionary<GameObject, GameObject> verticesPairs;

    List<Pair<Line, GameObject>> lines;

    void Update()
    {
        if (verticesPairs == null || lines == null)
        {
            InitProjectionVariables();
        }
        ShowProjection();
    }

    void InitProjectionVariables()
    {
        verticesPairs = new Dictionary<GameObject, GameObject>();
        LineDrawer lineDrawer = targerObject.GetComponent<LineDrawer>();
        foreach (GameObject point in lineDrawer.points)
        {
            GameObject projectionPoint = Instantiate(point, pointsContainer.transform);
            verticesPairs.Add(point, projectionPoint);
            projectionPoint.GetComponent<Renderer>().material = verticesMaterial;
            projectionPoint.transform.localScale *= pointsScaleCoefficient;
        }
        lines = new List<Pair<Line, GameObject>>();
        foreach (Line line in lineDrawer.lines)
        {
            Vector3 globalRespawnPosition = (line.point1.position + line.point2.position) / 2f;
            GameObject lineObject = Instantiate(linePrefab,
                globalRespawnPosition, linePrefab.transform.rotation, linesContainer.transform);
            lines.Add(new Pair<Line, GameObject>(new Line(verticesPairs[line.point1.gameObject].transform,
                verticesPairs[line.point2.gameObject].transform), lineObject));
        }
    }

    void ShowProjection()
    {
        Plane plane = new Plane();
        plane.SetNormalAndPosition(transform.up, transform.position);

        LineDrawer lineDrawer = targerObject.GetComponent<LineDrawer>();
        foreach (GameObject point in lineDrawer.points)
        {
            verticesPairs[point].transform.position = plane.ClosestPointOnPlane(point.transform.position);
        }

        foreach (Pair<Line, GameObject> pair in lines)
        {
            Vector3 globalPosition = (pair.First.point1.position + pair.First.point2.position) / 2f;
            GameObject lineObject = pair.Second;
            LineRenderer lineRenderer = lineObject.GetComponent<LineRenderer>();
            lineRenderer.positionCount = 2;
            lineRenderer.SetPositions(new Vector3[] { lineObject.transform.InverseTransformPoint(pair.First.point1.position),
                lineObject.transform.InverseTransformPoint(pair.First.point2.position) });
        }
    }
}
