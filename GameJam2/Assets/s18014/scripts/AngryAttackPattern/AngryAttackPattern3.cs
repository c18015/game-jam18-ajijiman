using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryAttackPattern3 : MonoBehaviour {
    public GameObject fireWallPrefab;
    public GameObject burstStreamPrefab;


    // Use this for initialization
    private void Awake()
    {
        setFireWall();
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
        burstStreamPrefab.GetComponent<BurstStream>().set(1f, 0.08f, 50f);
        StartCoroutine("firstAttack");
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
        yield return new WaitForSeconds(4f);
        while (isActiveAndEnabled) {
            Instantiate(burstStreamPrefab, new Vector2(8f, 3.3f), Quaternion.Euler(0f, 0f, 90f));
            Instantiate(burstStreamPrefab, new Vector2(8f, 2.3f), Quaternion.Euler(0f, 0f, 90f));
            Instantiate(burstStreamPrefab, new Vector2(8f, 1.3f), Quaternion.Euler(0f, 0f, 90f));
            yield return new WaitForSeconds(2.5f);

            Instantiate(burstStreamPrefab, new Vector2(8f, -3.3f), Quaternion.Euler(0f, 0f, 90f));
            Instantiate(burstStreamPrefab, new Vector2(8f, -2.3f), Quaternion.Euler(0f, 0f, 90f));
            Instantiate(burstStreamPrefab, new Vector2(8f, -1.3f), Quaternion.Euler(0f, 0f, 90f));
            yield return new WaitForSeconds(2.5f);
        }
    }

    IEnumerator fireWallAttack()
    {
        yield return new WaitForSeconds(2f);
        while (isActiveAndEnabled)
        {
            Instantiate(fireWallPrefab);
            yield return new WaitForSeconds(5f);
        }
    }

    IEnumerator firstAttack() {
        yield return new WaitForSeconds(1f);
        Instantiate(burstStreamPrefab, new Vector2(8f, 4.5f), Quaternion.Euler(0f, 0f, 90f));
        Instantiate(burstStreamPrefab, new Vector2(8f, 2.5f), Quaternion.Euler(0f, 0f, 90f));
        Instantiate(burstStreamPrefab, new Vector2(8f, -4.5f), Quaternion.Euler(0f, 0f, 90f));
        Instantiate(burstStreamPrefab, new Vector2(8f, -2.5f), Quaternion.Euler(0f, 0f, 90f));
        yield return new WaitForSeconds(1.4f);
        Instantiate(burstStreamPrefab, new Vector2(8f, 0f), Quaternion.Euler(0f, 0f, 90f));
    }


    void setFireWall()
    {
        FireWall fireWall = fireWallPrefab.GetComponent<FireWall>();
        fireWall.bulletNum = 20;
    }
}