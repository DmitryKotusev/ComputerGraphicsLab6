using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshDrawer : MonoBehaviour
{
    Vector3[] vertices;
    int[] triangles;
    Vector2[] uvs;
    Mesh mesh;

    private void Start()
    {
        InitVertices();
        InitTriangles();
        InitMesh();
        DrawMesh();
    }

    public int[] GetMeshTrianglesCopy()
    {
        int[] trianglesCopy = new int[triangles.Length];
        Array.Copy(triangles, trianglesCopy, triangles.Length);
        return trianglesCopy;
    }

    private void InitMesh()
    {
        mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.Optimize();
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
    }

    void InitVertices()
    {
        GameObject[] points = GetComponent<LineDrawer>().points;
        vertices = new Vector3[points.Length];
        for (int i = 0; i < points.Length; i++)
        {
            vertices[i] = points[i].transform.localPosition;
        }
    }

    void InitTriangles()
    {
        triangles = new int[]
        {
            //Back part//
            0, 1, 2,
            1, 3, 2,

            6, 4, 7,
            4, 5, 7,

            5, 8, 9,
            7, 5, 9,

            11, 10, 6,
            10, 4, 6,
            //Front part//
            12, 14, 13,
            14, 15, 13,

            16, 18, 19,
            19, 17, 16,

            17, 21, 20,
            19, 21, 17,

            18, 16, 23,
            16, 22, 23,
            //Left part//
            12, 0, 2,
            2, 14, 12,
            //Right part//
            10, 22, 16,
            16, 4, 10,
            4, 16, 17,
            17, 5, 4,
            5, 17, 20,
            20, 8, 5,
            //Bottom part//
            1, 0, 12,
            12, 13, 1,

            13, 18, 1,
            6, 1, 18,

            11, 6, 18,
            18, 23, 11,

            11, 23, 22,
            22, 10, 11,
            //Top part//
            15, 14, 2,
            2, 3, 15,

            19, 15, 7,
            15, 3, 7,

            21, 19, 7,
            7, 9, 21,

            20, 21, 8,
            21, 9, 8,
        };
    }

    void DrawMesh()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh = mesh;
    }
}
