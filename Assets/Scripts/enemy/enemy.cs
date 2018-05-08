using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using NPBehave;



namespace Complete
{
    public partial class enemy : MonoBehaviour
    {
        GameObject player;
        PlayerUI playerUI;
        Rigidbody rb;

        NavMeshAgent nav;
        Transform target;
        private float moveVelocity;
        private float turnVelocity;


        // Enemy Health
        public int enemyHealth;
        public int currentHealth;
        public int damage;

        private Blackboard blackboard;
        private Root behaviorTree;

        // Use this for initialization
        private void Start()
        {
            //  rb = GetComponent<Rigidbody>();
            nav = GetComponent<NavMeshAgent>();
            target = GameObject.Find("player").transform;
            playerUI = GameObject.Find("player").GetComponent<PlayerUI>();
            player = GameObject.Find("player1");
            rb = GetComponent<Rigidbody>();

            behaviorTree = CreateBehaviourTree();
            blackboard = behaviorTree.Blackboard;
            behaviorTree.Start();

        }

        // Update is called once per frame
        void Update()
        {
            Move();
            //enemyMovement();
        }

        /*
        void enemyMovement()
        {
            //sets the target of the enemy to the players position, following the player
            nav.SetDestination(target.position);
        }
        */

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

        private void Move()
        {
            Vector3 movement = transform.forward * moveVelocity;
            rb.MovePosition(rb.position + movement);
        }

        private void Turn()
        {
            float turn = turnVelocity * 180 * Time.deltaTime;
            Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
            rb.MoveRotation(rb.rotation * turnRotation);
        }

        private void MoveAI(float move)
        {
            //keeps the value of turnVelocity between -1 and 1
            moveVelocity = move;
        }

    }
}