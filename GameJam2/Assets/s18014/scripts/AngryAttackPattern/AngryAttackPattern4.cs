using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryAttackPattern4 : MonoBehaviour {
    public GameObject burstStreamPrefab;
    public GameObject finalAttackPrefab;
    GameObject player;
    // Use this for initialization
    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
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

    }

    IEnumerator attack () {
        yield return StartCoroutine("firstAttack");
        yield return StartCoroutine("secondAttack");
        yield return StartCoroutine("thirdAttack");
        yield return StartCoroutine("finalAttack");
    }

    IEnumerator firstAttack () {
        yield return new WaitForSeconds(1f);
        burstStreamPrefab.GetComponent<BurstStream>().set(1f, 0.08f, 50f);
        Instantiate(burstStreamPrefab, new Vector2(8f, 4f), Quaternion.Euler(0f, 0f, 90f));
        Instantiate(burstStreamPrefab, new Vector2(8f, -4f), Quaternion.Euler(0f, 0f, 90f));
        Instantiate(burstStreamPrefab, new Vector2(-5f, 5f), Quaternion.Euler(0f, 0f, 180f));
        Instantiate(burstStreamPrefab, new Vector2(0f, 5f), Quaternion.Euler(0f, 0f, 180f));
        Instantiate(burstStreamPrefab, new Vector2(5f, 5f), Quaternion.Euler(0f, 0f, 180f));
    }

    IEnumerator secondAttack () {
        burstStreamPrefab.GetComponent<BurstStream>().set(0.2f, 0.06f, 50f);
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < 15; i++) {
            Vector2 pos = randomPosition();
            Instantiate(burstStreamPrefab, pos, direction(pos));
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator thirdAttack () {
        burstStreamPrefab.GetComponent<BurstStream>().set(1f, 0.08f, 50f);
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 3; i++) {
            Instantiate(burstStreamPrefab, new Vector2(-12f + i * 7f, 5f), Quaternion.Euler(0f, 0f, -135f));
            yield return new WaitForSeconds(0.1f);
        }

        for (int i = 0; i < 3; i++)
        {
            Instantiate(burstStreamPrefab, new Vector2(12f - i * 7f, 5f), Quaternion.Euler(0f, 0f, 135f));
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(1.5f);

        for (int i = 0; i < 3; i++)
        {
            Instantiate(burstStreamPrefab, new Vector2(5f - i * 5f, 5f), Quaternion.Euler(0f, 0f, 180f));
            yield return new WaitForSeconds(0.1f);
        }

        for (int i = 0; i < 2; i++)
        {
            Instantiate(burstStreamPrefab, new Vector2(8f, 2f - i * 5f), Quaternion.Euler(0f, 0f, 90f));
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator finalAttack () {
        burstStreamPrefab.GetComponent<BurstStream>().set(0.1f, 0.06f, 50f);
        yield return new WaitForSeconds(1.7f);
        for (int i = 0; i < 8; i++) {
            Instantiate(burstStreamPrefab, new Vector2(8f, -5 + i * 1f), Quaternion.Euler(0f, 0f, 90f));
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(0.8f);

        for (int i = 0; i < 7; i++)
        {
            Instantiate(burstStreamPrefab, new Vector2(8f, 5 - i * 1f), Quaternion.Euler(0f, 0f, 90f));
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(0.8f);

        for (int i = 0; i < 15; i++)
        {
            Instantiate(burstStreamPrefab, new Vector2(8f - i * 1f, 5f), Quaternion.Euler(0f, 0f, 180f));
            yield return new WaitForSeconds(0.08f);
        }

        yield return new WaitForSeconds(0.8f);

        for (int i = 0; i < 13; i++)
        {
            Instantiate(burstStreamPrefab, new Vector2(-8f + i * 1f, 5f), Quaternion.Euler(0f, 0f, 180f));
            yield return new WaitForSeconds(0.08f);
        }

        yield return new WaitForSeconds(0.8f);

        Instantiate(finalAttackPrefab);
    }

    Quaternion direction(Vector2 position)
    {
        Vector2 pos = player.transform.position;
        pos -= position;
        pos.Normalize();
        return Quaternion.FromToRotation(Vector3.up, pos);

    }

    Vector2 randomPosition() {
        float p1;
        if (Random.Range(0, 2) == 0) p1 = 7; else p1 = -7;
        float p2 = Random.Range(-4.5f, 4.5f);
        return new Vector2(p1, p2);
    }


}
