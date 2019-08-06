using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : MonoBehaviour {
    Bullet bullet;
    float speed;
    float gravity = 9.81f;
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

    IEnumerator move ()
    {
        firstMove();
        yield return new WaitForSeconds(0.1f);
        secondMove();
    }

    void firstMove()
    {
        float angle = 45f;
        Vector2 dirction = Vector2.zero; 
        dirction.x = Mathf.Cos(Mathf.Deg2Rad * angle); 
        dirction.y = Mathf.Sin(Mathf.Deg2Rad * angle);
        dirction.Normalize();
        rig.velocity = dirction * speed / 2f;
        gravity = 0f;
        rig.velocity = Vector2.zero;
        Vector2 pos = transform.position;
        Vector2 direction = target - pos;
        direction.Normalize();
        rig.velocity = direction * speed / 2f;
 
    }

    void secondMove()
    {
        gravity = 0f;
        rig.velocity = Vector2.zero;
        Vector2 pos = transform.position;
        Vector2 direction = target - pos;
        direction.Normalize();
        rig.velocity = direction * speed;
    }

    public void shot()
    {
        bullet = GetComponent<Bullet>();
        speed = bullet.speed;
        rig = GetComponent<Rigidbody2D>();
        StartCoroutine("move");
    }

    void fall ()
    {
        Vector2 pos = Vector2.zero;
        pos.y = gravity * Time.deltaTime;
        rig.velocity -= pos;
    }
}