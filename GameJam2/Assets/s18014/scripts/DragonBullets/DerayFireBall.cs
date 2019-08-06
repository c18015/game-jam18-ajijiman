using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DerayFireBall : MonoBehaviour {
    Bullet bullet;
    float speed;
    Rigidbody2D rig;

	// Use this for initialization
	void Start () {
        StartCoroutine("shot");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void move() {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = new Vector2(-speed, 0f);
    }

    IEnumerator shot() {
        bullet = GetComponent<Bullet>();
        speed = bullet.speed;
        yield return new WaitForSeconds(bullet.deray);
        move();
    }
}
