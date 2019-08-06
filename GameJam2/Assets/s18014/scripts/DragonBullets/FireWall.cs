using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWall : MonoBehaviour {
    public int bulletNum;
    public GameObject derayFireBallPrafab;
    Bullet bullet;
    Vector2 min;
    Vector2 max;
    Vector2 size;

    // Use this for initialization
    void Start () {
        min = Camera.main.ViewportToWorldPoint(Vector2.zero);
        max = Camera.main.ViewportToWorldPoint(Vector2.one);
        size = max - min;
        bullet = GetComponent<Bullet>();
        StartCoroutine("makeWall");
    }

    // Update is called once per frame
    void Update () {
	}


    IEnumerator makeWall () {
        Vector2 pos = max;
        float massY = size.y / 5;
        float massX = size.x / 10;
        pos.x -= size.x / 10;
        for (int i = 0; i < bulletNum; i++) {
            pos.y = max.y - massY * Random.Range(0, 5) - massY / 2f;
            pos.x = max.x - massX * Random.Range(0f, 3f);
            Instantiate(derayFireBallPrafab, pos, Quaternion.identity);
            yield return new WaitForSeconds(bullet.deray);
        }

        Destroy(gameObject);
    }

}
