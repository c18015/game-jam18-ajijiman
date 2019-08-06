using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBreathGenerator : MonoBehaviour {
    Bullet bullet;
    public GameObject fireBreathPrefab;
    public float angle;
    public int bulletNum;

	// Use this for initialization
	void Start () {
        bullet = GetComponent<Bullet>();
        StartCoroutine("shot");
	}
	
	// Update is called once per frame
	void Update () {
    }

    IEnumerator shot () {
        for (int i = 0; i < bulletNum; i++) {
            Instantiate(fireBreathPrefab, transform.position, transform.rotation);
            transform.Rotate(new Vector3(0, 0, angle));
            yield return new WaitForSeconds(bullet.deray);
        }
        Destroy(gameObject);
    }

}
