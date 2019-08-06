using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {
    Dragon dragon;
    Animator animator;
	// Use this for initialization
	void Start () {
        dragon = GameObject.FindWithTag("Enemy").GetComponent<Dragon>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (dragon.isAngry)
        {
            animator.SetBool("isAngry", true);
        } else {
            animator.SetBool("isAngry", false);
        }
    }
}
