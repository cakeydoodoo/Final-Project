using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class enemy : MonoBehaviour
{

    Rigidbody rb;

    NavMeshAgent nav;
    public Transform target;


    // Enemy Health
    public int enemyHealth;
    public int currentHealth;

    public int damage;


    // Use this for initialization
    void Start()
    {

        //  rb = GetComponent<Rigidbody>();
        nav = GetComponent<NavMeshAgent>();



    }

    void Awake()
    {


    }

    // Update is called once per frame


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
        Destroy(this.gameObject);
    }

}
