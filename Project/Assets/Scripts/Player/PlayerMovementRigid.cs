using Microsoft.Win32;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PlayerMovementRigid : MonoBehaviour
{

    public float speed = 1000f;
    Rigidbody rb;
    public float sensitivity = 100f;
    float xRotation = 0f;
    Camera cam;
    Vector2 velocity;

    public GameObject groundCheck;
    bool isGrounded;
    public float checkSize;
    public float jumpForce = 100f;
    bool jumpReq;
    public LayerMask groundMask;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 xMov = new Vector2(Input.GetAxisRaw("Horizontal") * transform.right.x, Input.GetAxisRaw("Horizontal") * transform.right.z);
        Vector2 zMov = new Vector2(Input.GetAxisRaw("Vertical") * transform.forward.x, Input.GetAxisRaw("Vertical") * transform.forward.z);

        velocity = (xMov + zMov).normalized * speed * Time.deltaTime;

        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        isGrounded = Physics.CheckSphere(groundCheck.transform.position, checkSize, groundMask);

        if (Input.GetButtonDown("Jump") && isGrounded) jumpReq = true; ;

       
    }

    void FixedUpdate()
    {


        if (jumpReq)
        {
            rb.AddForce(new Vector3(0, jumpForce));
            jumpReq = false;
        }

        rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.y);

    }


}
