using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour {

    public Material mat;
    Vector3[] vertices;
    Mesh mesh;
    float value1;
    float value2;

    public void SetValues(float v1, float v2) {
        this.value1 = v1;
        this.value2 = v2;
    }
    // Use this for initialization
    void Start () {
        mesh = new Mesh();
        vertices = new Vector3[3];

        vertices[0] = new Vector3(-1, 0);
        vertices[1] = new Vector3(0, value1);
        vertices[2] = new Vector3(value2,0);

        //assign the array of colors to the Mesh.
        mesh.vertices = vertices;
        mesh.triangles = new int[] {0, 1, 2};

        //mat.color = 
        GetComponent<MeshRenderer>().material = mat;
        GetComponent<MeshFilter>().mesh = mesh;
     }
}
