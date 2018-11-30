using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour {

    public Material mat;
    public bool isBorder;

    Vector3[] vertices;
    Mesh mesh;
    float value1;
    float value2;
    Color triangleColor;

    public static readonly Color[] availableTriangles = new Color[] {
     new Color(0.89f, 0.52f, 0.46f), new Color(0.2f,0.4f,0.8f), new Color(0.57f, 0.23f, 0.74f) };

    void Start() {
        CreateTriangle();
    }

    public void SetValues(float v1, float v2) {
        value1 = v1;
        value2 = v2;
        CreateTriangle();
    }

    void CreateTriangle() {
        mesh = new Mesh();
        vertices = new Vector3[3];

        if (!isBorder) {
            DefineVerticesTriangle();
            DefineColors();
        } else { DefineVerticesBorder(); }

        //assign the array of colors to the Mesh.
        mesh.vertices = vertices;
        mesh.triangles = new int[] { 0, 1, 2 };

        GetComponent<MeshRenderer>().material = mat;
        GetComponent<MeshRenderer>().material.color = triangleColor;
        GetComponent<MeshFilter>().mesh = mesh;
    }

    void DefineVerticesTriangle() {
        vertices[0] = new Vector3(-1, 0);
        vertices[1] = new Vector3(0, value1);
        vertices[2] = new Vector3(value2, 0);
    }

    void DefineVerticesBorder() {
        vertices[0] = new Vector3(-1.2f, -0.2f);
        vertices[1] = new Vector3(0, value1);
        vertices[2] = new Vector3(value2, -0.2f);
    }

    void DefineColors() {
        int colorIndex = Random.Range(0, availableTriangles.Length);
        triangleColor = availableTriangles[colorIndex];
    }
}
