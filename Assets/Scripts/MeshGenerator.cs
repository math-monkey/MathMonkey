using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour {

    public Material mat;
    Vector3[] vertices;
    Mesh mesh;
    float value1;
    float value2;

    public static readonly Color[] availableTriangles = new Color[] {
     new Color(0.89f, 0.52f, 0.46f), new Color(0.2f,0.4f,0.8f), new Color(0.57f, 0.23f, 0.74f) };

    public void SetValues(float v1, float v2) {
        value1 = v1;
        value2 = v2;
        CreateTriangle();
    }
    // Use this for initialization
    void Start () {
        mesh = new Mesh();
        vertices = new Vector3[3];
        CreateTriangle();
     }

    void CreateTriangle() {
        vertices[0] = new Vector3(-1, 0);
        vertices[1] = new Vector3(0, value1);
        vertices[2] = new Vector3(value2, 0);

        //assign the array of colors to the Mesh.
        mesh.vertices = vertices;
        mesh.triangles = new int[] { 0, 1, 2 };

        //mat.color = 
        int colorIndex = Random.Range(0, availableTriangles.Length);
        Color triangleColor = availableTriangles[colorIndex];
        mat.color = triangleColor;
        GetComponent<MeshRenderer>().material = mat;
        GetComponent<MeshFilter>().mesh = mesh;
    }
}
