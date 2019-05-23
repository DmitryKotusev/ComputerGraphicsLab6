using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshDrawer : MonoBehaviour
{
    Vector3[] vertices;
    int[] triangles;
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

    public Vector3[] GetMeshVerticesCopy()
    {
        Vector3[] verticesCopy = new Vector3[vertices.Length];
        Array.Copy(vertices, verticesCopy, vertices.Length);
        return verticesCopy;
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
        vertices = new Vector3[] {
            //Back part//
            points[0].transform.localPosition, // 0
            points[1].transform.localPosition, // 1
            points[2].transform.localPosition, // 2
            points[3].transform.localPosition, // 3

            points[4].transform.localPosition, // 4
            points[5].transform.localPosition, // 5
            points[6].transform.localPosition, // 6
            points[7].transform.localPosition, // 7

            points[5].transform.localPosition, // 8
            points[7].transform.localPosition, // 9
            points[8].transform.localPosition, // 10
            points[9].transform.localPosition, // 11

            points[4].transform.localPosition, // 12
            points[6].transform.localPosition, // 13
            points[10].transform.localPosition, // 14
            points[11].transform.localPosition, // 15
            //Front part//
            points[12].transform.localPosition, // 16
            points[13].transform.localPosition, // 17
            points[14].transform.localPosition, // 18
            points[15].transform.localPosition, // 19

            points[16].transform.localPosition, // 20
            points[17].transform.localPosition, // 21
            points[18].transform.localPosition, // 22
            points[19].transform.localPosition, // 23

            points[17].transform.localPosition, // 24
            points[19].transform.localPosition, // 25
            points[20].transform.localPosition, // 26
            points[21].transform.localPosition, // 27

            points[16].transform.localPosition, // 28
            points[18].transform.localPosition, // 29
            points[22].transform.localPosition, // 30
            points[23].transform.localPosition, // 31
            //Left part//
            points[0].transform.localPosition, // 32
            points[2].transform.localPosition, // 33
            points[12].transform.localPosition, // 34
            points[14].transform.localPosition, // 35
            //Right part//
            points[4].transform.localPosition, // 36
            points[10].transform.localPosition, // 37
            points[16].transform.localPosition, // 38
            points[22].transform.localPosition, // 39

            points[4].transform.localPosition, // 40
            points[5].transform.localPosition, // 41
            points[16].transform.localPosition, // 42
            points[17].transform.localPosition, // 43

            points[5].transform.localPosition, // 44
            points[8].transform.localPosition, // 45
            points[17].transform.localPosition, // 46
            points[20].transform.localPosition, // 47
            //Bottom part//
            points[0].transform.localPosition, // 48
            points[1].transform.localPosition, // 49
            points[12].transform.localPosition, // 50
            points[13].transform.localPosition, // 51

            points[1].transform.localPosition, // 52
            points[6].transform.localPosition, // 53
            points[13].transform.localPosition, // 54
            points[18].transform.localPosition, // 55

            points[6].transform.localPosition, // 56
            points[11].transform.localPosition, // 57
            points[18].transform.localPosition, // 58
            points[23].transform.localPosition, // 59

            points[10].transform.localPosition, // 60
            points[11].transform.localPosition, // 61
            points[22].transform.localPosition, // 62
            points[23].transform.localPosition, // 63
            //Top part//
            points[2].transform.localPosition, // 64
            points[3].transform.localPosition, // 65
            points[14].transform.localPosition, // 66
            points[15].transform.localPosition, // 67

            points[3].transform.localPosition, // 68
            points[7].transform.localPosition, // 69
            points[15].transform.localPosition, // 70
            points[19].transform.localPosition, // 71

            points[7].transform.localPosition, // 72
            points[9].transform.localPosition, // 73
            points[19].transform.localPosition, // 74
            points[21].transform.localPosition, // 75

            points[8].transform.localPosition, // 76
            points[9].transform.localPosition, // 77
            points[20].transform.localPosition, // 78
            points[21].transform.localPosition, // 79
        };
    }

    void InitTriangles()
    {
        triangles = new int[]
        {
            //Back part//
            0, 1, 2, //
            1, 3, 2, //Ready!
            //
            6, 4, 7, //
            4, 5, 7, //Ready!
            //
            8, 10, 11, //
            9, 8, 11, //Ready!
            //
            15, 14, 13, //
            14, 12, 13, //Ready!
            //Front part//
            16, 18, 17, //
            18, 19, 17, //Ready!
            //
            20, 22, 23, //
            23, 21, 20, //Ready!
            //
            24, 27, 26, //
            25, 27, 24, //Ready!
            //
            29, 28, 31, //
            28, 30, 31, //Ready!
            //Left part//
            34, 32, 33, //
            33, 35, 34, //Ready!
            //Right part//
            37, 39, 38, //
            38, 36, 37, //Ready!
            //
            40, 42, 43, //
            43, 41, 40, //Ready!
            //
            44, 46, 47, //
            47, 45, 44, //Ready!
            //Bottom part//
            49, 48, 50, //
            50, 51, 49, //Ready!
            //
            54, 55, 52, //
            53, 52, 55, //Ready!
            //
            57, 56, 58, //
            58, 59, 57, //Ready!
            //
            61, 63, 62, //
            62, 60, 61, //Ready!
            //Top part//
            67, 66, 64, //
            64, 65, 67, //Ready!
            //
            71, 70, 69, //
            70, 68, 69, //Ready!
            //
            75, 74, 72, //
            72, 73, 75, //Ready!
            //
            78, 79, 76, //
            79, 77, 76, //Ready!
        };
    }

    void DrawMesh()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh = mesh;
    }
}
