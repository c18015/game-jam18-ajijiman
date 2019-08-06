using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragonUIManager : MonoBehaviour {
    Dragon dragon;
    GameObject[] UIs;
    Slider hpSlider;
    Slider angrySlider;

	// Use this for initialization
	void Start () {
        dragon = GameObject.Find("Dragon").gameObject.GetComponent<Dragon>();
        hpSlider = transform.Find("DragonHp").Find("Slider").GetComponent<Slider>();
        angrySlider = transform.Find("DragonAngry").Find("Slider").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update () {
        hpSlider.value = dragon.hungryPoint / dragon.maxHungryPoint;
        angrySlider.value = dragon.angryPoint / dragon.maxAngryPoint;
	}
}
