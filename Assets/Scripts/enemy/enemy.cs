using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using NPBehave;



namespace Complete
{
    public partial class Enemy : MonoBehaviour
    {

        Rigidbody rb;
        Animator anim;

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
            target = GameObject.Find("player").transform;
            rb = GetComponent<Rigidbody>();
            anim = GetComponent<Animator>();

            behaviorTree = CreateBehaviourTree();
            blackboard = behaviorTree.Blackboard;
            behaviorTree.Start();

        }

        // Update is called once per frame
        void Update()
        {
            Move();
            Turn();
        }


         void die()
        {
            UIManager.scoreNumber += 1;
            gameObject.SetActive(false);
            GetComponent<Rigidbody>().isKinematic = true;
            //Destroy(this.gameObject);
            //destroys the game object and then adds 1 to the players score
        }

        /*
        //FIX THIS, IT DESTROYS THE ENEMIES WHEN THEY SPAWN
        void OnCollisionEnter(Collision other)
        {
                if (other.gameObject == player)
            {
                playerUI.TakeDamage(10);
            }  

        }
                    */

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
            moveVelocity = move;
            anim.SetBool("walk", true);
        }

        private void TurnAI(float turn)
        {
            turnVelocity = turn;
        }

        private void Stop()
        {
            anim.SetBool("walk", false);
        }

        private void attack()
        {
            anim.SetTrigger("attack");
        }

    }
}