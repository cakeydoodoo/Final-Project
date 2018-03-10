using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponChangeLeft : MonoBehaviour {
    public GameObject[] weapons;

    public int currentWeapon = 0;

    private int changeWeapon;

    void Start()
    {

        changeWeapon = weapons.Length;

        SwitchWeapon(currentWeapon);

    }

    void Update()
    {
        for (int i = 1; i <= changeWeapon; i++)
        {
            if (Input.GetKeyDown("" + i))
            {
                currentWeapon = i - 1;

                SwitchWeapon(currentWeapon);

            }
        }

    }

    void SwitchWeapon(int index)
    {

        for (int i = 0; i < changeWeapon; i++)
        {
            if (i == index)
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