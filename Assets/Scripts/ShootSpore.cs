using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ShootSpore : MonoBehaviour {

    public GameObject theProjectile;
    public float shootTime;
    public int chanceShoot;
    public Transform shootFrom;

    float nextShootTime;

    // Use this for initialization
    void Start () {
        nextShootTime = 0f;
    }
    
    // Update is called once per frame
    void Update () {
        
    }

	void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Player" && nextShootTime < Time.time) {
            nextShootTime = Time.time + shootTime;
            if(Random.Range(0,10) >= chanceShoot) {
                Instantiate(theProjectile, shootFrom.position, Quaternion.identity);
            }
        }
    }
}
