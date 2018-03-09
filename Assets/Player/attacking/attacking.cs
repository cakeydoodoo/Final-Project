using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attacking : MonoBehaviour {
    public int currentWeapon = 0;
    public GameObject [] weapons;
    private int changeWeapon;

    // Use this for initialization
    void Start () {
        changeWeapon = weapons.Length;
        SwitchWeapon(currentWeapon);
	}
	
	// Update is called once per frame
	void Update () {
		for(int i= 0; i <changeWeapon; i++)
        {
            if(Input.GetKeyDown("" + i))
            {
                currentWeapon = i - 1;
                SwitchWeapon(currentWeapon);

            }
        }
	}

    void SwitchWeapon(int index)
    {
        for(int i=0; i < changeWeapon; i++)
        {
            if(i == index)
            {
                weapons[i].gameObject.SetActive(true);
            }
            else
            {
                weapons[i].gameObject.SetActive(false);
            }
        }
    }
    
}