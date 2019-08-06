using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour {
    public GameObject[] foodPrefabs;
    public int equip = 0;
    public AudioClip[] audioClips;
    Bullet[] bullets;
    float[] lapTimes;
    bool[] isAttackable;
    Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        bullets = new Bullet[foodPrefabs.Length];
        lapTimes = new float[foodPrefabs.Length];
        isAttackable = new bool[foodPrefabs.Length];
        for (int i = 0; i < foodPrefabs.Length; i++)
        {
            bullets[i] = foodPrefabs[i].GetComponent<Bullet>();
            lapTimes[i] = 0f;
            isAttackable[i] = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
        changeFoods();
        checkAttackable();
        shot();
		
	}

    void shot () {
        if (Input.GetMouseButton(0))  {
            if (isAttackable[equip] == true)
            {
                Instantiate(foodPrefabs[equip], transform.position, Quaternion.identity);
                isAttackable[equip] = false;
                lapTimes[equip] = 0f;
                animator.SetTrigger("Throw");
                AudioSource.PlayClipAtPoint(audioClips[0], transform.position);
            }
        }
    }

    void checkAttackable ()
    {
        for (int i = 0; i < foodPrefabs.Length; i++)
        {
            lapTimes[i] += Time.deltaTime;
            if (lapTimes[i] >= bullets[i].deray)
            {
                isAttackable[i] = true;
            }
        }
    }

    void changeFoods() {
        if (Input.GetMouseButtonDown(1)) {
            equip += 1;
            if (equip > 2) equip = 0;
        }
    }
}