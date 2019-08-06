using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBody : MonoBehaviour {
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
        if (other.gameObject.tag == "PlayerBullet")
        {
            if (!dragon.isAngry) {
                dragon.angryPoint += other.gameObject.GetComponent<Bullet>().angry;
            }
            if (dragon.angryPoint > dragon.maxAngryPoint) dragon.angryPoint = dragon.maxAngryPoint;
            if (dragon.angryPoint < 0f) dragon.angryPoint = 0f;
            AudioSource.PlayClipAtPoint(audioClip, transform.position);
            Destroy(other.gameObject);
        }
    }
}
