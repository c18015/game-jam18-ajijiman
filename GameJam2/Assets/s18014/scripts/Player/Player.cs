using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public int hp;
    public AudioClip audioClip;
    int maxHp;
    bool isInvincible = false;
    SpriteRenderer spr;
    Vector2 min;
    Vector2 max;

    // Use this for initialization
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        maxHp = hp;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        move();
    }

    void move()
    {
        // Y方向への移動可能領域を食べ物アイコンの高さ分制限
        float diffY = 96f / 720f;
        min = Camera.main.ViewportToWorldPoint(Vector2.zero);
        max = Camera.main.ViewportToWorldPoint(Vector2.one);
        min.y -= min.y * diffY * 2f;

        Vector2 size = GetComponent<SpriteRenderer>().bounds.size / 2f;
        Vector2 pos = transform.position;
        Vector2 rot = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
            );
        rot.Normalize();
        pos += rot * speed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, min.x + size.x, max.x - size.x);
        pos.y = Mathf.Clamp(pos.y, min.y + size.y, max.y - size.y);
        transform.position = pos;
    }

    IEnumerator invincible () {
        // 無敵処理
        isInvincible = true;
        StartCoroutine("lighting");
        yield return new WaitForSeconds(2f);
        isInvincible = false;
    }

    IEnumerator lighting () {
        // 無適時の点滅処理
        while(isInvincible) {
            spr.color = new Color(1f, 1f, 1f, 0.2f);
            yield return new WaitForSeconds(0.1f);
            spr.color = new Color(1f, 1f, 1f, 0.5f);
            yield return new WaitForSeconds(0.1f);
        }
        spr.color = new Color(1f, 1f, 1f, 1f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EnemyBullet") {
            if (isInvincible) {
                return;
            }

            StartCoroutine("invincible");
            hp -= 1;
            if (hp < 0) hp = 0;
            AudioSource.PlayClipAtPoint(audioClip, transform.position);
        }
    }
}