using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBreath : MonoBehaviour {
    Bullet bullet;
    float speed;
    Rigidbody2D rig;

    // Use this for initialization
    void Start () {
        move();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void move () {
        speed = GetComponent<Bullet>().speed;
        rig = GetComponent<Rigidbody2D>();
        Vector2 direction = transform.rotation * Vector2.up;
        rig.velocity = direction * speed;
    }
}
