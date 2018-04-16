using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyer : MonoBehaviour {

    public attacking script;
    //Rigidbody rb;
    Animator anim;


    private void Awake()
    {
        //rb = GetComponent<Rigidbody>();
        anim = GameObject.Find("playerPrefab").GetComponent<Animator>();

    }
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision col)
    {
        //if the current animation is playing then....
        if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("sword&shield.slash") | 
            this.anim.GetCurrentAnimatorStateInfo(0).IsName("sword&shield.backhand") |
            this.anim.GetCurrentAnimatorStateInfo(0).IsName("sword&shield.spin") |
            this.anim.GetCurrentAnimatorStateInfo(0).IsName("sword&shield.runAttack") |
            this.anim.GetCurrentAnimatorStateInfo(0).IsName("sword&shield.turn") |
            this.anim.GetCurrentAnimatorStateInfo(0).IsName("greatsword.slash") |
            this.anim.GetCurrentAnimatorStateInfo(0).IsName("greatsword.highslash") |
            this.anim.GetCurrentAnimatorStateInfo(0).IsName("greatsword.slash") |
            this.anim.GetCurrentAnimatorStateInfo(0).IsName("greatsword.slam") |
            this.anim.GetCurrentAnimatorStateInfo(0).IsName("daggers.dagger1") |
            this.anim.GetCurrentAnimatorStateInfo(0).IsName("daggers.dagger2") |
            this.anim.GetCurrentAnimatorStateInfo(0).IsName("daggers.thrust") |
            this.anim.GetCurrentAnimatorStateInfo(0).IsName("daggers.combo") |
            this.anim.GetCurrentAnimatorStateInfo(0).IsName("daggers.runAttack") |
            this.anim.GetCurrentAnimatorStateInfo(0).IsName("hand.jab") |
            this.anim.GetCurrentAnimatorStateInfo(0).IsName("hand.body") |
            this.anim.GetCurrentAnimatorStateInfo(0).IsName("hand.leftHook") |
            //this.anim.GetCurrentAnimatorStateInfo(0).IsName("hand.fireball") |
            this.anim.GetCurrentAnimatorStateInfo(0).IsName("hand.kick") |
            this.anim.GetCurrentAnimatorStateInfo(0).IsName("hand.kick2") |
            this.anim.GetCurrentAnimatorStateInfo(0).IsName("hand.kick3") |
            this.anim.GetCurrentAnimatorStateInfo(0).IsName("hand.fly") |
            this.anim.GetCurrentAnimatorStateInfo(0).IsName("hand.sweep"))
        {
            // the game object enemy if it is hit by the weapon
            if (col.gameObject.GetComponent<enemy>())
            {
                col.gameObject.SendMessage("die");
            }       

        }

        //Destroy(this.gameObject, 2);
    }

}
