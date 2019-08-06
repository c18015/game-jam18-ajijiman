using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPattern1 : MonoBehaviour {
    public GameObject multiFireBallPrefab;
    GameObject player;
    Animator dragonAnime;
    Bullet bullet;

    // Use this for initialization

    private void Awake()
    {
        bullet = multiFireBallPrefab.GetComponent<Bullet>();
        player = GameObject.FindWithTag("Player");
        dragonAnime = GameObject.FindWithTag("Enemy").GetComponent<Animator>();
    }

    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnEnable()
    {
        set(30f, 3);
        StartCoroutine("attack");
    }

    private void OnDisable()
    {
        StopCoroutine("attack");
    }

    IEnumerator attack () {
        yield return new WaitForSeconds(1f);
        while (isActiveAndEnabled)
        {
            // first attack
            dragonAnime.SetTrigger("Attack");
            Quaternion rot = direction();
            for (int i = 0; i < 3; i++)
            {
                yield return new WaitForSeconds(bullet.deray);
                Instantiate(multiFireBallPrefab, transform.position, rot);
            }

            yield return new WaitForSeconds(1f);

            // second attack
            dragonAnime.SetTrigger("Attack");
            rot = direction();
            for (int i = 0; i < 3; i++)
            {
                yield return new WaitForSeconds(bullet.deray);
                Instantiate(multiFireBallPrefab, transform.position, rot);
            }

            yield return new WaitForSeconds(1f);
        }

    }

    Quaternion direction () {
        Vector2 pos = player.transform.position - transform.position;
        pos.Normalize();
        return Quaternion.FromToRotation(Vector3.up, pos);

    }

    void set (float angle, int num) {
        MulitFireBall multiFireBall = multiFireBallPrefab.GetComponent<MulitFireBall>();
        multiFireBall.angle = angle;
        multiFireBall.numberOfBullet = num;
    }
}
