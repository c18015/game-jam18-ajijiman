using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPattern2 : MonoBehaviour {
    public GameObject fireBreathGeneratorPrefab;
    Animator dragonAnime;


    // Use this for initialization
    private void Awake()
    {
        dragonAnime = GameObject.FindWithTag("Enemy").GetComponent<Animator>();
    }
    void Start () {
    }

    // Update is called once per frame
    void Update () {
    }

    private void OnEnable()
    {
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
            dragonAnime.SetTrigger("Attack");
            set(20f, 12);
            Instantiate(fireBreathGeneratorPrefab, transform.position, Quaternion.Euler(0f, 0f, Random.Range(-75f, -90f)));
            yield return new WaitForSeconds(1.5f);

            dragonAnime.SetTrigger("Attack");
            set(-20f, 12);
            Instantiate(fireBreathGeneratorPrefab, transform.position, Quaternion.Euler(0f, 0f, Random.Range(-75f, -90f)));
            yield return new WaitForSeconds(1.5f);
        }
    }

    void set (float angle, int num) {
        FireBreathGenerator fireBreathGenjrator = fireBreathGeneratorPrefab.GetComponent<FireBreathGenerator>();
        fireBreathGenjrator.angle = angle;
        fireBreathGenjrator.bulletNum = num;
    }
}
