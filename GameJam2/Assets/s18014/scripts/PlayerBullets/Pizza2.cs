using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza2 : MonoBehaviour {
    public float RangeOfAngle;
    Bullet bullet;
    float speed;
    Rigidbody2D rig;
    Vector2 target;



	// Use this for initialization
	void Start () {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RangeOfAngle = Random.Range(-RangeOfAngle, RangeOfAngle);
        shot();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void shot()
    {
        bullet = GetComponent<Bullet>();
        speed = bullet.speed;
        speed = speed * Random.Range(0.7f, 1f);
        rig = GetComponent<Rigidbody2D>();
        Vector2 pos = transform.position;
        Vector2 direction = target - pos;
        direction.Normalize();
        Quaternion rot = Quaternion.Euler(0f, 0f, RangeOfAngle);
        float diffRot = Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI;
        if (diffRot > 180f) diffRot -= 360f;
        if (diffRot < -180f) diffRot += 360f;
        direction = rot * direction;
        rig.velocity = direction * speed;

        transform.rotation = Quaternion.Euler(0, 0, diffRot + RangeOfAngle + 45f);
    }
}
