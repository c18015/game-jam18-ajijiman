using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeController : MonoBehaviour {
    public GameObject heartPrefab;
    GameObject[] hearts;
    SpriteRenderer[] heartRenderers;
    GameObject player;
    SpriteRenderer spRenderer;
    Player playerStatus;
    int maxHp;
    Vector2 size;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").gameObject;
        spRenderer = player.GetComponent<SpriteRenderer>();
        playerStatus = player.GetComponent<Player>();
        maxHp = playerStatus.hp;
        hearts = new GameObject[maxHp];
        heartRenderers = new SpriteRenderer[maxHp];
        size = spRenderer.bounds.size;
        for (int i = 0; i < maxHp; i++)
        {
            hearts[i] = Instantiate(heartPrefab, Vector2.zero, Quaternion.identity);
            heartRenderers[i] = hearts[i].GetComponent<SpriteRenderer>();
        }
	}
	
	// Update is called once per frame
	void Update () {
        setHearts();
        resetHeartsObj();
        checkHeartsExists();
	}

    void setHearts ()
    {
        Vector2 pos = player.transform.position;
        float massX = size.x * 2f / maxHp;
        float minX = pos.x - size.x;
        pos.y += size.y / 2f + 0.5f;
        for (int i = 0; i < maxHp; i++)
        {
            pos.x = minX + massX * i + massX / 2f;
            hearts[i].transform.position = pos;
        }
    }

    void checkHeartsExists()
    {
        for (int i = 0; i < playerStatus.hp; i++)
        {
            heartRenderers[i].enabled = true;
        }
    }

    void resetHeartsObj ()
    {
        foreach (SpriteRenderer renderer in heartRenderers)
        {
            renderer.enabled = false;
        }
    }
}