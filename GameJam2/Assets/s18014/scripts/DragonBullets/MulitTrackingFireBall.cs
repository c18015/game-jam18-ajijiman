using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MulitTrackingFireBall : MonoBehaviour {
    public GameObject trackingFireBallPrefab;
    public int numberOfBullet;
    public float angle;
    TrackingFireBall TFB;

	// Use this for initialization
	void Start () {
        makeFireBalls();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void makeFireBalls () {
        TFB = trackingFireBallPrefab.GetComponent<TrackingFireBall>();
        int halfNum = (int)Mathf.Floor(numberOfBullet/ 2);
        float firstAngle = halfNum * -angle;
        if (numberOfBullet % 2 == 0) firstAngle += angle / 2;
        for (int i = 0; i < numberOfBullet; i++) {
            TFB.angle = firstAngle + angle * i;
            Instantiate(trackingFireBallPrefab, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
