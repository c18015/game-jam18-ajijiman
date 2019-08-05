using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_Frame : MonoBehaviour
{
   
    public Vector2 speed = new Vector2(0.05f, 0.05f);  // 速度

    public GameObject targetObject;     // ターゲットとなるオブジェクト

    private float rad;                  // ラジアン変数

    private Vector2 Position;          // 現在位置を代入する為の変数



    void Start()
    {
        rad = Mathf.Atan2(
            targetObject.transform.position.y - transform.position.y,
            targetObject.transform.position.x - transform.position.x);
    }

    
    void Update()
    {
       
        Position = transform.position;       // 現在位置をPositionに代入
      
        Position.x += speed.x * Mathf.Cos(rad);
        Position.y += speed.y * Mathf.Sin(rad);
       
        transform.position = Position;   // 現在の位置に加算減算を行ったPositionを代入する
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Dango" || other.gameObject.tag == "Pizza" || other.gameObject.tag == "Nikuman")
        {
            Destroy(other.gameObject);
        }
    }

    /*
        public int speed = 4;
        public float lifeTime = 5;

        void Start()
        {
            GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;
            Destroy(gameObject, lifeTime);
        }*/
}
