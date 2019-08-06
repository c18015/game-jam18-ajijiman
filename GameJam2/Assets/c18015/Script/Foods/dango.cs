using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dango : MonoBehaviour {

    public int DangookoP;
    public int DangoDM;
    public nemuHP nemuHp;
    public okoHP okoHp;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Dragon_Head")
        {

            nemuHp.Addnemu(DangoDM);

            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "Hazure")
        {
            okoHp.Addoko(DangookoP);

            Destroy(this.gameObject);
        }


    }
}
