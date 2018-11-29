using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour {

    public Material mat;
    Vector3[] vertices;
    Mesh mesh;
    //float width = 0;
    //float height = 1;

    // Use this for initialization
    void Start () {
        mesh = new Mesh();
        vertices = new Vector3[3];

        vertices[0] = new Vector3(-1, 0);
        vertices[1] = new Vector3(0, 4);
        vertices[2] = new Vector3(1,0);

        //assign the array of colors to the Mesh.
        mesh.vertices = vertices;
        mesh.triangles = new int[] {0, 1, 2};

        GetComponent<MeshRenderer>().material = mat;
        GetComponent<MeshFilter>().mesh = mesh;
     }
}
