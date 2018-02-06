using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float movementSpeed;
    public float rotationSpeed;
    public float runSpeed;
    public float speed;
    public float jumpForce;

    static Animator anim;
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
            jump();

        }



    }

    void Movement()
    {

        //set players speed
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;

        }else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = movementSpeed;
        }

        /*
        //run
        if (Input.GetKeyDown(KeyCode.LeftShift) | Input.GetKeyDown("w"))
        {
            anim.SetBool("walkRun",true);
            anim.SetBool("idleWalk", false);
        }//idle
        else if(Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp("w"))
        {
            anim.SetBool("idleRun", false);
        }
        // walk
        else if (Input.GetKeyUp(KeyCode.LeftShift) | Input.GetKeyDown("w"))
        {
            anim.SetBool("idleWalk",true);
        }//idle
        else if (Input.GetKeyUp(KeyCode.LeftShift) | Input.GetKeyUp("w"))
        {
            anim.SetBool("idleWalk", false);
            anim.SetBool("walkRun", false);

        }
        */  

        if (Input.GetKeyUp(KeyCode.LeftShift) | Input.GetKeyUp("w"))
        {
            anim.SetBool("idleWalk", false);
            anim.SetBool("walkRun", false);
        } else if(Input.GetKeyUp(KeyCode.LeftShift) | Input.GetKeyDown("w"))
        {
            anim.SetBool("idleWalk", true);
            anim.SetBool("walkRun", false);
        }//running
        else if (Input.GetKeyDown(KeyCode.LeftShift) | Input.GetKeyDown("w"))
        {
            anim.SetBool("walkRun", true);
            //anim.SetBool("idleWalk", false);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) | Input.GetKeyDown("w"))
        {
            anim.SetBool("idleWalk", true);
            anim.SetBool("walkRun", false);
        }



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

    void jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        anim.SetTrigger("jump");

    }


}
