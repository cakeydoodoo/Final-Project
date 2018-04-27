using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;



public class enemy : MonoBehaviour
{

    Rigidbody rb;

    NavMeshAgent nav;
    Transform target; 


    // Enemy Health
    public int enemyHealth;
    public int currentHealth;
    public int damage;


    // Use this for initialization
    void Start()
    {
        //  rb = GetComponent<Rigidbody>();
        nav = GetComponent<NavMeshAgent>();
        target = GameObject.Find("player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        enemyMovement();
    }

    void enemyMovement()
    {
        nav.SetDestination(target.position);
    }


    void die()
    {
        UIManager.scoreNumber += 1;
        Destroy(this.gameObject);

    }

}
