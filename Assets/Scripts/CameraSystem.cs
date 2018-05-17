using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour {

    public Transform target; // What camera is following
    public float smoothing;

    Vector3 offset;
    float lowY;
    float lowX;

    // Use this for initialization
    void Start() {
        offset = transform.position;
        lowY = transform.position.y;
        lowX = transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate() {
        Vector3 targetCamPos = target.position + offset;
        var nextPos = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        transform.position = new Vector3(Mathf.Max(nextPos.x, lowX), Mathf.Max(nextPos.y, lowY), nextPos.z);
    }
}
