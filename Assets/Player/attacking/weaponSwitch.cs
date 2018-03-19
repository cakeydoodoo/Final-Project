using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponSwitch : MonoBehaviour {
    public GameObject[] weapons;

    public PlayerMovement script;

    public int currentWeapon = 0;
    private int changeWeapon;
    static Animator anim;

    private void Awake()
    {
        {
            anim = GameObject.Find("playerPrefab").GetComponent<Animator>();
        }
    } 

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

        attack();

    }

    void attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("shieldSlash", true);
        }
        else if(Input.GetButtonUp("Fire1"))
        {
            anim.SetBool("shieldSlash", false);
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