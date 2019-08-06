using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalAttack : MonoBehaviour {
    public GameObject burstStreamPrefab;
    public Vector2 center;
    public float radius;
    public float angle;
    public float startAngle;
    public float numberOfBullet;
    Bullet bullet;

	// Use this for initialization
	void Start () {
        bullet = GetComponent<Bullet>();
        set();
        StartCoroutine("fire");
	}
	
	// Update is called once per frame
	void Update () {
    }

    IEnumerator fire () {
        Vector2 pos;
        for (int i = 0; i < numberOfBullet; i++) {
            pos.x = center.x + Mathf.Cos(Mathf.Deg2Rad * angle * i + startAngle) * radius;
            pos.y = center.y + Mathf.Sin(Mathf.Deg2Rad * angle * i + startAngle) * radius;
            Instantiate(burstStreamPrefab, pos, direction(center, pos));
            yield return new WaitForSeconds(bullet.deray);
        }

    }

    Quaternion direction(Vector2 target, Vector2 self)
    {
        Vector2 pos = target - self;
        pos.Normalize();
        return Quaternion.FromToRotation(Vector3.up, pos);

    }

    void set() {
        BurstStream burstStream = burstStreamPrefab.GetComponent<BurstStream>();
        Bullet burstStreamBullet = burstStream.GetComponent<Bullet>();
        GameObject burstFire = burstStream.burstFirePrefab;
        Bullet burstFireBullet = burstFire.GetComponent<Bullet>();

        burstStream.time = 0.1f;
        burstStreamBullet.deray = 0.08f;

        burstFireBullet.speed = 50f;
    }
}
