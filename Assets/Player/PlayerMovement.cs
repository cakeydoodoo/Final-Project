using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float movementSpeed;
    public float rotationSpeed;

    Rigidbody rb;
    Camera myCamera;
    public float jumpForce;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        myCamera = Camera.main;
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
        //player movement
        Vector3 inputVelocity = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        inputVelocity = inputVelocity * movementSpeed * Time.deltaTime;
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

    }


}
