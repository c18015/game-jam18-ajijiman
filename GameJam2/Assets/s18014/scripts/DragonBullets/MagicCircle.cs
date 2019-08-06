using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCircle : MonoBehaviour {
    float angleZ;
    float angleX = 90f;

	// Use this for initialization
	void Start () {
        Vector2 pos = transform.position;
        pos.x -= 13f;
	}
	
	// Update is called once per frame
	void Update () {
        angleZ += 30f * Time.deltaTime;
        angleX -= 5f * Time.deltaTime;
        if (angleX < 87f) angleX = 87f;
        transform.localRotation = Quaternion.Euler(angleX, 0f, angleZ);
	}
}
