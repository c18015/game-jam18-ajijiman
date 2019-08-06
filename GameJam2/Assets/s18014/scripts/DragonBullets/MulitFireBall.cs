using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MulitFireBall : MonoBehaviour {
    public GameObject fireBallPrefab;
    public int numberOfBullet;
    public float angle;
    FireBall fireBall;

    // Use this for initialization
    void Start()
    {
        makeFireBalls();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void makeFireBalls()
    {
        fireBall = fireBallPrefab.GetComponent<FireBall>();
        int halfNum = (int)Mathf.Floor(numberOfBullet / 2);
        float firstAngle = halfNum * -angle;
        if (numberOfBullet % 2 == 0) firstAngle += angle / 2;
        for (int i = 0; i < numberOfBullet; i++)
        {
            fireBall.angle = firstAngle + angle * i;
            Instantiate(fireBallPrefab, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }
}