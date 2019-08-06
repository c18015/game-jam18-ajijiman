using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonHead : MonoBehaviour {
    Dragon dragon;
    public AudioClip audioClip;

	// Use this for initialization
	void Start () {
        dragon = transform.parent.gameObject.GetComponent<Dragon>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerBullet") {
            AudioSource.PlayClipAtPoint(audioClip, transform.position);
            if (dragon.isAngry) {
                dragon.angryPoint -= other.gameObject.GetComponent<Bullet>().power * 0.2f;
                if (dragon.angryPoint > dragon.maxAngryPoint) dragon.angryPoint = dragon.maxAngryPoint;
                if (dragon.angryPoint < 0f) dragon.angryPoint = 0f;
                Destroy(other.gameObject);
            }
            else {
                dragon.hungryPoint -= other.gameObject.GetComponent<Bullet>().power;
                if (dragon.hungryPoint > dragon.maxHungryPoint) dragon.hungryPoint = dragon.maxHungryPoint;
                if (dragon.hungryPoint < 0f) dragon.hungryPoint = 0f;
                Destroy(other.gameObject);
            }
        }
    }
}
