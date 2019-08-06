using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPattern3 : MonoBehaviour {
    public GameObject fireWallPrefab;
    public GameObject fireBreathGeneratorPrefab;
    Animator dragonAnime;


    // Use this for initialization
    private void Awake()
    {
        dragonAnime = GameObject.FindWithTag("Enemy").GetComponent<Animator>();
        setFireWall();
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update() {
    }

    private void OnEnable()
    {
        StartCoroutine("attack");
        StartCoroutine("fireWallAttack");
    }

    private void OnDisable()
    {
        StopCoroutine("attack");
        StopCoroutine("firewallAttack");
    }

    IEnumerator attack()
    {
        yield return new WaitForSeconds(1f);
        while (isActiveAndEnabled)
        {
            dragonAnime.SetTrigger("Attack");
            setFireBreath(20f, 10);
            Instantiate(fireBreathGeneratorPrefab, transform.position, Quaternion.Euler(0f, 0f, -90f));
            yield return new WaitForSeconds(2.5f);

            dragonAnime.SetTrigger("Attack");
            setFireBreath(-20f, 10);
            Instantiate(fireBreathGeneratorPrefab, transform.position, Quaternion.Euler(0f, 0f, -90f));
            yield return new WaitForSeconds(2.5f);
        }

    }

    IEnumerator fireWallAttack() {
        yield return new WaitForSeconds(1f);
        while (isActiveAndEnabled) 
        {
            Instantiate(fireWallPrefab);
            yield return new WaitForSeconds(8f);
        }
    }


    void setFireWall()
    {
        FireWall fireWall = fireWallPrefab.GetComponent<FireWall>();
        fireWall.bulletNum = 20;
    }

    void setFireBreath(float angle, int num)
    {
        FireBreathGenerator fireBreathGenjrator = fireBreathGeneratorPrefab.GetComponent<FireBreathGenerator>();
        fireBreathGenjrator.angle = angle;
        fireBreathGenjrator.bulletNum = num;
    }
}
