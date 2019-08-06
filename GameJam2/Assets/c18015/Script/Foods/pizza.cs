using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pizza : MonoBehaviour {

    public okoHP okoHp;
    public nemuHP nemuHp;
    public int PizzaDM;
    public int PizzaokoP;

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
            nemuHp.Addnemu(PizzaDM);

            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "Hazure")
        {
            okoHp.Addoko(PizzaokoP);

            Destroy(this.gameObject);
        }
    }
}
