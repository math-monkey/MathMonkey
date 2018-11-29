using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleController : MonoBehaviour {

    public GameObject triangleObject;
    int triangleType;

    void Start() {
        UpdateTriangle();
    }

    public int GetNumber() {
        return triangleType;
    }

    public void UpdateTriangle() {
        int idx = Random.Range(0, TriangleHelper.availableTriangles.Length);
        //enemyTriangle = TriangleHelper.availableTriangles[idx];
        //MeshGenerator meshGenerator = new MeshGenerator(2, 1)
        MeshGenerator meshGenerator = triangleObject.GetComponent<MeshGenerator>();
        meshGenerator.SetValues(2, 1);
        //enemyNumberUI.text = enemyNumber.ToString();
    }
}
