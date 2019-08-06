using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingFireBall : MonoBehaviour {
    Bullet bullet;
    float speed;
    public float angle;
    Rigidbody2D rig;
    Vector2 target;

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform.position;
        shot();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void shot()
    {
        bullet = GetComponent<Bullet>();
        speed = bullet.speed;
        rig = GetComponent<Rigidbody2D>();
        Vector2 pos = transform.position;
        Vector2 direction = target - pos;
        direction.Normalize();

        Quaternion rot = Quaternion.Euler(0f, 0f, angle);
        float newRot = Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI;
        if (newRot > 180f) newRot -= 360f;
        if (newRot < -180f) newRot += 360f;
        direction = rot * direction;
        rig.velocity = direction * speed;

        transform.rotation = Quaternion.Euler(0, 0, newRot + angle);
    }
}