using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Dragon_HP : MonoBehaviour
{

    public int nemuHP ;
    public int okoHP = 0;

    // Use this for initialization
    void Start()
    {
        if (nemuHP < 100)
            nemuHP = 0;

        if (okoHP < 70)
            okoHP = 0;

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerStay2D(Collider2D other)
    {   

    }


    /*
        public void dango ()
        {
            nemuHp.AddDangoo(DangoDM);
        }

        public void pizza ()
        {
            nemuHp.AddPizza(PizzaDM);
        }

        public void nikuman ()
        {
            nemuHp.AddNikuman(NikumanDM);
        }*/
}
