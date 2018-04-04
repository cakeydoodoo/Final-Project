using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponSwitch : MonoBehaviour {

    //public PlayerMovement script;
    public GameObject[] weapons;
    Animator anim;

    public int currentWeapon = 0;
    private int changeWeapon;
    
    
    private void Awake()
    {
        anim = GameObject.Find("playerPrefab").GetComponent<Animator>();

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
        Debug.Log(currentWeapon);

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



    void attack()
    {        
        
        //changes the animations depending on the weapon equipped

        if(weapons[0].activeSelf)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                anim.SetTrigger("greatSlash");
            }
            if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("greatsword.highslash"))
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    anim.SetTrigger("greatSlash2");
                }
            }
            /*
            else if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("greatsword.slash"))
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    anim.SetTrigger("shieldSlash3");
                }
            }
            */

        }
        else if (weapons[1].activeSelf)
        {

            if (Input.GetButtonDown("Fire1"))
            {
                anim.SetTrigger("shieldSlash");
            }

            if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("sword&shield.slash"))
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    anim.SetTrigger("shieldSlash2");
                }
            }
            else if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("sword&shield.backhand"))
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    anim.SetTrigger("shieldSlash3");
                }
            }



            if (anim.GetBool("run") == true)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    if (anim.GetBool("idleRight") == true || anim.GetBool("idleLeft"))
                    {
                        anim.SetTrigger("shieldStrafe");
                    }
                    else anim.SetTrigger("shieldRun");
                }
            } 
                    
        }
            else if (weapons[2].activeSelf)
            {

            }
            else if(weapons[3].activeSelf)
            {

            }

    }


    }