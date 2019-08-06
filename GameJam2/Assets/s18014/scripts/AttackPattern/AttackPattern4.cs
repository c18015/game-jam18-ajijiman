using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPattern4 : MonoBehaviour {
    public GameObject multiFireBallPrefab;
    Animator dragonAnime;
    float objAngle;

    // Use this for initialization

    private void Awake()
    {
        dragonAnime = GameObject.FindWithTag("Enemy").GetComponent<Animator>();
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        objAngle += Time.deltaTime * 60f;
    }
    
    private void OnEnable()
    {
        set(30f, 12);
        StartCoroutine("attack");
    }
    
    private void OnDisable()
    {
        StopCoroutine("attack");
    }


    IEnumerator attack()
    {
        yield return new WaitForSeconds(1f);
        while (isActiveAndEnabled)
        {
            // first attack
            dragonAnime.SetTrigger("Attack");
            set(30f, 12);
            for (int i = 0; i < 15; i++)
            {
                yield return new WaitForSeconds(0.3f);
                Instantiate(multiFireBallPrefab, transform.position, Quaternion.Euler(0f, 0f, objAngle));
            }
    
            yield return new WaitForSeconds(1.5f);
        }
    
    }
    
    void set(float angle, int num)
    {
        MulitFireBall multiFireBall = multiFireBallPrefab.GetComponent<MulitFireBall>();
        multiFireBall.angle = angle;
        multiFireBall.numberOfBullet = num;
    }
}