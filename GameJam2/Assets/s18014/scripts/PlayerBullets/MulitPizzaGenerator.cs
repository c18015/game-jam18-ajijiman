using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MulitPizzaGenerator : MonoBehaviour {
    public int bulletNum;
    public GameObject pizzaPrefab;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < bulletNum; i++) {
            Instantiate(pizzaPrefab, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
