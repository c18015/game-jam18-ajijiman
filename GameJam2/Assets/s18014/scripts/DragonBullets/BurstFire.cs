using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstFire : MonoBehaviour {
    Bullet bullet;
    float speed;
    Rigidbody2D rig;
    Vector2 target;


    // Use this for initialization
    void Start () {
        shot();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void shot()
    {
        bullet = GetComponent<Bullet>();
        speed = bullet.speed;
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = transform.up * speed;
    }
}
