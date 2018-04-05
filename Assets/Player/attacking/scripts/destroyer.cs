using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyer : MonoBehaviour {

    public attacking script;
    Rigidbody rb;
    Animator anim;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
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
            this.anim.GetCurrentAnimatorStateInfo(0).IsName("greatsword.highslash"))
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
