using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstStream : MonoBehaviour {
    Bullet bullet;
    public GameObject burstFirePrefab;
    public float time;
    public float deray;
    public AudioClip[] audioClips;
    AudioSource audioSource;
    float curentTime;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClips[0];
        AudioSource.PlayClipAtPoint(audioClips[0], transform.position, 500f);
        bullet = GetComponent<Bullet>();
        time += deray;
        StartCoroutine("shot");
    }

    // Update is called once per frame
    void Update()
    {
        curentTime += Time.deltaTime;
    }

    IEnumerator shot()
    {
        yield return new WaitForSeconds(deray);
        audioSource.clip = audioClips[1];
        AudioSource.PlayClipAtPoint(audioClips[1], transform.position);
        while (true)
        {
            Instantiate(burstFirePrefab, transform.position, transform.rotation);
            if (curentTime > time) break;
            yield return new WaitForSeconds(bullet.deray);
        }
        Destroy(gameObject);
    }

    public void set(float time, float deray, float speed)
    {
        Bullet burstStreamBullet = this.GetComponent<Bullet>();
        Bullet burstFireBullet = this.burstFirePrefab.GetComponent<Bullet>();

        this.time = time;
        burstStreamBullet.deray = deray;
        burstFireBullet.speed = speed;
    }
}
