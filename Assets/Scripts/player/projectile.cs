﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class projectile : MonoBehaviour {

    Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    // Use this for initialization
    void Start()
    {
        rb.AddForce(transform.forward * 7.5f, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<Complete.enemy>())
        {
            col.gameObject.SendMessage("die");
        }

        Destroy(this.gameObject);

    }


}
