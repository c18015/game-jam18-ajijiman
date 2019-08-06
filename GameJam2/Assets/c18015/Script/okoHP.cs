using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class okoHP : MonoBehaviour {

    Slider _slider;

    // Use this for initialization
    void Start() {
        _slider = GameObject.Find("oko_Gauge").GetComponent<Slider>();

    }
    float okoHp = 0;

	
	// Update is called once per frame
	void Update () {

        _slider.value = okoHp;

    }

    public void Addoko(int amount)
    {
      okoHp  += amount;
    }
}
