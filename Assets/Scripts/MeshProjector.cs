using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshProjector : MonoBehaviour
{
    public GameObject targerObject;
    Vector3[] vertices;
    int[] triangles;
    Mesh mesh;

    void Update()
    {
        if (vertices == null || triangles == null)
        {
            InitProjectionVariables();
        }
        ShowProjection();
    }

    void InitProjectionVariables()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
    }

    void ShowProjection()
    {
        Plane plane = new Plane();
        plane.SetNormalAndPosition(transform.up, transform.position);

        MeshFilter targetMeshFilter = targerObject.GetComponent<MeshFilter>();
        triangles = targetMeshFilter.mesh.triangles;

        vertices = new Vector3[targetMeshFilter.mesh.vertices.Length];
        for (int i = 0; i < targetMeshFilter.mesh.vertices.Length; i++)
        {
            vertices[i] =
                transform.InverseTransformPoint(
                plane.ClosestPointOnPlane(
                    targerObject.transform.TransformPoint(targetMeshFilter.mesh.vertices[i])
                    ));
        }

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.Optimize();
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
    }
}
