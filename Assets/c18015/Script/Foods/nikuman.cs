using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nikuman : MonoBehaviour {

    public nemuHP nemuHp;
    public okoHP okoHp;
    public int NikumanDM;
    public int NikumanokoP;

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
            nemuHp.Addnemu(NikumanDM);

            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "Hazure")
        {
            okoHp.Addoko(NikumanokoP);

            Destroy(this.gameObject);
        }

    }

        

}
