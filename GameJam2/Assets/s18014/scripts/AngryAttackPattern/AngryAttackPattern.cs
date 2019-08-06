using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryAttackPattern : MonoBehaviour {
    public GameObject multiFireBallPrefab;
    public GameObject burstStreamPrefab;
    GameObject player;
    Bullet bullet;

    // Use this for initialization

    private void Awake()
    {
        bullet = multiFireBallPrefab.GetComponent<Bullet>();
        player = GameObject.FindWithTag("Player");
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnEnable()
    {
        set(20f, 5);
        StartCoroutine("attack");
        StartCoroutine("firstAttack");
    }

    private void OnDisable()
    {
        StopCoroutine("attack");
    }

    IEnumerator attack()
    {
        yield return new WaitForSeconds(3f);
        while (isActiveAndEnabled)
        {
            // first attack
            Quaternion rot = direction();
            for (int i = 0; i < 3; i++)
            {
                yield return new WaitForSeconds(bullet.deray);
                Instantiate(multiFireBallPrefab, transform.position, rot);
            }

            yield return new WaitForSeconds(0.2f);

            // second attack
            rot = direction();
            for (int i = 0; i < 3; i++)
            {
                yield return new WaitForSeconds(bullet.deray);
                Instantiate(multiFireBallPrefab, transform.position, rot);
            }

            yield return new WaitForSeconds(0.2f);
        }

    }

    IEnumerator firstAttack() {
        burstStreamPrefab.GetComponent<BurstStream>().set(1f, 0.08f, 50f);
        yield return new WaitForSeconds(1f);
        Instantiate(burstStreamPrefab, new Vector2(8f, 1f), Quaternion.Euler(0f, 0f, 90f));
    }

    Quaternion direction()
    {
        Vector2 pos = player.transform.position - transform.position;
        pos.Normalize();
        return Quaternion.FromToRotation(Vector3.up, pos);

    }

    void set(float angle, int num)
    {
        MulitFireBall multiFireBall = multiFireBallPrefab.GetComponent<MulitFireBall>();
        multiFireBall.angle = angle;
        multiFireBall.numberOfBullet = num;
    }
}