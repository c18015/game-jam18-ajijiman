using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time1 : MonoBehaviour {

    public int TM;
    private GUIStyle style;
    private float counter = 0
;

    void Start()
    {
        style = new GUIStyle();
        style.fontSize = 30;
    }

    void Update()
    {
        counter += Time.deltaTime;
        if (counter > 1)
        {
            TM--;
            counter = 0;
        }

    }

    void OnGUI()
    {
        if (TM > 30)
        {
            GUI.Label(new Rect(5, 0, 100, 100), "" + TM, style);
            //↑ 文字""と数字pHPを足すと文字で出る
        }
    }

	
	// Update is called once per frame
	void Update2 () {
		
	}
}
