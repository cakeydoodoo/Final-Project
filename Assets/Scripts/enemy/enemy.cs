using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;



public class enemy : MonoBehaviour
{
    GameObject player;
    PlayerUI playerUI;
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
        playerUI = GameObject.Find("player").GetComponent<PlayerUI>();
        player = GameObject.Find("player1");


    }

    // Update is called once per frame
    void Update()
    {
        enemyMovement();
    }

    void enemyMovement()
    {
        //sets the target of the enemy to the players position, following the player
        nav.SetDestination(target.position);
    }


    void die()
    {
        UIManager.scoreNumber += 1;
        Destroy(this.gameObject);
        //destroys the game object and then adds 1 to the players score
    }

    //FIX THIS, IT DESTROYS THE ENEMIES WHEN THEY SPAWN
    void OnCollisionEnter(Collision other)
    {
        if (//other.gameObject.GetComponent<enemy>()
            other.gameObject == player
            )
        {
            playerUI.TakeDamage(10);
            other.gameObject.SendMessage("die");
        }
        //Destroy(this.gameObject);

    }

}
