using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleController : MonoBehaviour {

    public GameObject triangleObject;
    MeshGenerator meshGenerator;
    int enemyTriangle;

    void Start() {
        UpdateTriangle();
    }

    public int GetNumber() {
        return enemyTriangle;
    }

    public void UpdateTriangle() {
        int idx = Random.Range(0, TriangleHelper.availableTriangles.Length);
        enemyTriangle = TriangleHelper.availableTriangles[idx];
        meshGenerator = triangleObject.GetComponent<MeshGenerator>();
        SetTriangle();
    }

    public void SetTriangle() {
        switch (enemyTriangle) {
            case 1:
                meshGenerator.SetValues(2, 1); //Equilateral Triangle
                break;
            case 2:
                meshGenerator.SetValues(4, 1); //Isosceles Triangle
                break;
            case 3:
                meshGenerator.SetValues(2, 3); //Scalene Triangle
                break;
            default:
                break;
        }
    }
}
