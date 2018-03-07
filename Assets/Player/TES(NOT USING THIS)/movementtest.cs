using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movementtest : MonoBehaviour
{

    public float movementSpeed;
    public float rotationSpeed;
    public float runSpeed;
    public float speed;
    public float jumpForce;
    public float run = 1;

    //public Coroutine StartCorountine;

    static Animator anim;
    Rigidbody rb;
    Camera myCamera;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        myCamera = Camera.main;
        anim = GetComponent<Animator>();
    }

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        Movement();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(jump());


        }

    }

    IEnumerator wait()
    {
        yield return new WaitForSecondsRealtime(1f);
    }

    void Movement()
    {

        

        if (Input.anyKey == false)
        {
            anim.SetFloat("input x", 0);
            anim.SetFloat("input z", 0);

        }
        else if (Input.GetKeyDown("w"))
        {
            anim.SetFloat("input x", 0);
            anim.SetFloat("input z", 0.5f*run);
        }//running

        else if (Input.GetKeyDown("s"))
        {
            anim.SetFloat("input x", 0);
            anim.SetFloat("input z", -0.5f*run);
        }
        else if(Input.GetKeyDown("a"))
        {
            anim.SetFloat("input x", -0.5f*run);
            anim.SetFloat("input z", 0);

        }
        else if (Input.GetKeyDown("d"))
        {
            anim.SetFloat("input x", 0.5f * run);
            anim.SetFloat("input z", 0);
        }


//set players speed
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            run = 2;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = movementSpeed;
            run = 1;
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


    }


}
