using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float power;
    public float speed;
    public float angry;
    public float deray;
	// Use this for initialization
	void Start ()
    {

    }

    // Update is called once per frame
    void Update () {

    }
    private void OnTriggerExit2D(Collider2D c)
    {
        string layerName = LayerMask.LayerToName(c.gameObject.layer);
        if (layerName == "DestroyArea")
        {
            Destroy(gameObject);
        }
    }
}