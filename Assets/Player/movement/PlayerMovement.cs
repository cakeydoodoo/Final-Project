using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    //public attacking script2;

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


        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(jump());
        }
        Movement();

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
            anim.SetBool("run", false);
        }
        if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("sword&shield.slash") |
        this.anim.GetCurrentAnimatorStateInfo(0).IsName("sword&shield.backhand") |
        this.anim.GetCurrentAnimatorStateInfo(0).IsName("sword&shield.spin") |
        this.anim.GetCurrentAnimatorStateInfo(0).IsName("sword&shield.turn") |
        this.anim.GetCurrentAnimatorStateInfo(0).IsName("greatsword.slash") |
        this.anim.GetCurrentAnimatorStateInfo(0).IsName("greatsword.highslash") |
        this.anim.GetCurrentAnimatorStateInfo(0).IsName("greatsword.slash") |
        this.anim.GetCurrentAnimatorStateInfo(0).IsName("greatsword.slam") |
        this.anim.GetCurrentAnimatorStateInfo(0).IsName("daggers.dagger1") |
        this.anim.GetCurrentAnimatorStateInfo(0).IsName("daggers.dagger2") |
        this.anim.GetCurrentAnimatorStateInfo(0).IsName("daggers.thrust") |
        this.anim.GetCurrentAnimatorStateInfo(0).IsName("daggers.combo") |
        this.anim.GetCurrentAnimatorStateInfo(0).IsName("hand.jab") |
        this.anim.GetCurrentAnimatorStateInfo(0).IsName("hand.body") |
        this.anim.GetCurrentAnimatorStateInfo(0).IsName("hand.leftHook") |
        this.anim.GetCurrentAnimatorStateInfo(0).IsName("hand.fireball") |
        this.anim.GetCurrentAnimatorStateInfo(0).IsName("hand.kick") |
        this.anim.GetCurrentAnimatorStateInfo(0).IsName("hand.kick2") |
        this.anim.GetCurrentAnimatorStateInfo(0).IsName("hand.kick3") |
        this.anim.GetCurrentAnimatorStateInfo(0).IsName("hand.sweep"))
        {
            speed = 0;
        }
        else if (anim.GetBool("run") == false)
        {
            speed = movementSpeed;

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

