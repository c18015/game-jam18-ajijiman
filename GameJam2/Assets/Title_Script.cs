using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_Script : MonoBehaviour {


    public GameObject Bottan;
    public int time;


    public void OsStartButtonClicked()
    {
        Application.LoadLevel("BattleScene");
    }




    // Use this for initialization
    void Start() {

        Bottan.SetActive(false);

        Invoke("hogehoge", time);
        
    }

    // Update is called once per frame
    void Update() {





    }

    void hogehoge()
    {
        Bottan.SetActive(true);
    }
}
