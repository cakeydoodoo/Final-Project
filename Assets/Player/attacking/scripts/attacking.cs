﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attacking : MonoBehaviour {

    public weaponSwitch script2;

     Animator anim;


    private void Awake()
    {
        {
            anim = GameObject.Find("playerPrefab").GetComponent<Animator>();
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        attack();
	}




    void attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("shieldSlash");
            //anim.SetBool("slash",true);
        }
        if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("attack.slash"))
        {
            if (Input.GetButtonDown("Fire1"))
            {
                anim.SetTrigger("shieldSlash2");
                //anim.SetBool("slash2",true);
            }
        }
        else if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("attack.spin"))
        {
            if (Input.GetButtonDown("Fire1"))
            {
                anim.SetTrigger("shieldSlash3");
                //anim.SetBool("slash2",true);
            }
        }
        

    }



}
