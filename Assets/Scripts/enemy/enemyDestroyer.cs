using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDestroyer : MonoBehaviour {

    Animator anim;
    GameObject player;
    PlayerUI playerUI;
    //public GameObject enemyPrefab;

    private void Awake()
    {
        //GameObject enemyExample = Instantiate(enemyPrefab, transform.position, transform.rotation) as GameObject;
    }

    // Use this for initialization
    void Start ()
    {
        //anim = GameObject.Find("enemy").GetComponent<Animator>();
        playerUI = GameObject.Find("player").GetComponent<PlayerUI>();
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnCollisionEnter(Collision other)
    {
        
            if (other.gameObject == player)
            {
                playerUI.TakeDamage(1f);
            }

    }
}

