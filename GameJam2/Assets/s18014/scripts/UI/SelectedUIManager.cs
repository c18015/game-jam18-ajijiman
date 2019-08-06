using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedUIManager : MonoBehaviour {
    SelectedFoodUI[] isSelecteds;
    BulletManager bulletM;

	// Use this for initialization
	void Start () {
        isSelecteds = GetComponentsInChildren<SelectedFoodUI>();
        bulletM = GameObject.Find("Player").GetComponent<BulletManager>();
	}
	
	// Update is called once per frame
	void Update () {
        checkSelected();
	}

    void checkSelected ()
    {
        for (int i = 0; i < bulletM.foodPrefabs.Length; i++)
        {
            if (bulletM.equip == i)
            {
                isSelecteds[i].IsSelected = true;
            }
            else
            {
                isSelecteds[i].IsSelected = false;
            }
        }
    }
}
