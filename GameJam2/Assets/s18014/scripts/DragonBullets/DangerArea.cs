using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerArea : MonoBehaviour {
    SpriteRenderer spr;
    float alpha = 0f;

	// Use this for initialization
	void Start () {
        spr = GetComponent<SpriteRenderer>();
        spr.color = new Color(1f, 0f, 0f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
        alpha += 1f * Time.deltaTime;
        if (alpha > 0.3f) alpha = 0.3f;
        spr.color = new Color(1f, 0f, 0f, alpha);
	}
}
