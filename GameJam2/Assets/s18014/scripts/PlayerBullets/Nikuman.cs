using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nikuman : MonoBehaviour {
    Bullet bullet;
    float speed;
    float gravity = 9.81f * 2f;
    Rigidbody2D rig;
    Vector2 target;

	// Use this for initialization
	void Start () {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        shot();
	}
	
	// Update is called once per frame
	void Update () {
        fall();
	}

    void shot() {
        bullet = GetComponent<Bullet>();
        speed = bullet.speed;
        rig = GetComponent<Rigidbody2D>();
        Vector2 pos = transform.position;
        Vector2 direction = target - pos;
        direction.Normalize();
        rig.velocity = direction * speed;
    }

    void fall() {
        rig = GetComponent<Rigidbody2D>();
        Vector2 pos = Vector2.zero;
        pos.y = gravity * Time.deltaTime;
        rig.velocity -= pos;
    }

}
