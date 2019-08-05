using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class nemuHP : MonoBehaviour {


    Slider _slider;

    // Use this for initialization
    void Start () {
        _slider = GameObject.Find("nemu_Gauge").GetComponent<Slider>();

    }
    float nemuHp = 0;

    // Update is called once per frame
    void Update () {








        _slider.value = nemuHp;
    }

  
    public void Addnemu(int amount)
    {
        nemuHp += amount;
    }

   
    /*
    public void AddNikuman(int amount)
    {
        nemuHp += amount;
    }*/
}
