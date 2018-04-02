using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    public attacking script2;

    public float movementSpeed;
    public float rotationSpeed;
    public float runSpeed;
    public float speed;
    public float jumpForce;
    public float run;
    //public Coroutine StartCorountine;

    Animator anim;
    Rigidbody rb;
    Camera myCamera;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        myCamera = Camera.main;
        anim = GetComponent<Animator>();
    }

    void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {

        Movement();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(jump());
        }
        if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("attack.slash"))
        {
            movementSpeed = 0;
            runSpeed = 0;
        }
        else
        {

        }

    }

    IEnumerator wait()
    {
        yield return new WaitForSecondsRealtime(1f);
    }

    void Movement()
    {

        //set players speed
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            anim.SetBool("run", true);

        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = movementSpeed;
            anim.SetBool("run", false);
        }


        if (Input.GetKeyDown("w"))
        {
            anim.SetBool("idleWalk", true);
        }
        else if (Input.GetKeyUp("w"))
        {
            anim.SetBool("idleWalk", false);
        }

        if (Input.GetKeyDown("s"))
        {
            anim.SetBool("idleBack", true);
        }
        else if (Input.GetKeyUp("s"))
        {
            anim.SetBool("idleBack", false);
        }

        if (Input.GetKeyDown("a"))
        {
            anim.SetBool("idleLeft", true);
        }
        else if (Input.GetKeyUp("a"))
        {
            anim.SetBool("idleLeft", false);
        }

        if (Input.GetKeyDown("d"))
        {
            anim.SetBool("idleRight", true);
        }
        else if (Input.GetKeyUp("d"))
        {
            anim.SetBool("idleRight", false);
        }


        /*
        if (Input.GetKeyUp(KeyCode.LeftShift) | Input.GetKeyUp("w"))
        {
            anim.SetBool("idleWalk", false);
            anim.SetBool("walkRun", false);
        }
       
        else if(Input.GetKeyUp(KeyCode.LeftShift) | Input.GetKeyDown("w"))
        {
            anim.SetBool("idleWalk", true);
            anim.SetBool("walkRun", false);
        }//running
        else if (Input.GetKeyDown(KeyCode.LeftShift) | Input.GetKeyDown("w"))
        {
            anim.SetBool("walkRun", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) | Input.GetKeyDown("s"))
        {
            anim.SetBool("idleBack", true);
        } 
        else if(Input.GetKeyUp(KeyCode.LeftShift) | Input.GetKeyUp("s"))
        {
            anim.SetBool("idleBack", false);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) | Input.GetKeyDown("w"))
        {
            anim.SetBool("idleWalk", true);
            anim.SetBool("walkRun", false);
        }
        
    */




        //player movement
        Vector3 inputVelocity = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        inputVelocity = inputVelocity * speed * Time.deltaTime;
        rb.MovePosition(transform.position + (transform.forward * inputVelocity.z) + (transform.right * inputVelocity.x));





        //camera rotation
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        float horizontalRotation = mouseX * rotationSpeed * Time.deltaTime;
        float verticalRotation = mouseY * rotationSpeed * Time.deltaTime;

        transform.Rotate(Vector3.up, horizontalRotation);
        myCamera.transform.rotation = myCamera.transform.rotation * Quaternion.Euler(new Vector3(-verticalRotation, 0f, 0f));
    }

    IEnumerator jump()
    {
        anim.SetTrigger("jump");
        //allows the animation to play before the player jumps
        yield return new WaitForSeconds(0.55f);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        yield return new WaitForSeconds(0.15f);
        anim.SetTrigger("fall");
        //ADD A RAYCAST IF YOU WANNA DO JUMPS AT DIFFERENT HEIGHTS.
        anim.SetTrigger("land");

    }


}
