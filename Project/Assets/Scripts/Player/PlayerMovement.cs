using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float defaultSpeed = 7f;
    public float reducedSpeed;
    public float normalSpeed;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float reducedHeight = 0.7f;
    public float crouchTime = 0.1f;
    public float jumpStaminaCost = 10f;
 
    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;   

    public Transform model;
    Vector3 velocity;
    bool isGrounded;
    bool jumpRequest;
    bool isCrouched;
    bool crouchRequest;
    bool underCollider;
    public bool isSprinting;
    bool gravityReset;
    public bool onIce;
    public bool inWater;
    public bool isDrowning;

    public float speed;
    float slopeForce = 3f;
    float slopeForceRayLenght = 3f;
    float originalHeight = 2.4f;
    float x = 0;
    float z = 0;
    Vector3 transformRight;
    Vector3 transformForward;
    int jumpCount = 0;

    public PlayerAttributes playerAttributes;
    public Inventory inventory;

    public bool inputEnabled = true;

    void Start()
    {
        reducedSpeed = defaultSpeed / 1.5f;
        normalSpeed = defaultSpeed;
        speed = defaultSpeed;
        originalHeight = controller.height;
        inventory = GetComponent<Inventory>();
        playerAttributes = GetComponent<PlayerAttributes>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        var startPos = transform.position + new Vector3(0, reducedHeight - (originalHeight * 0.4f), 0);
        var length = (originalHeight - reducedHeight);

        if(inputEnabled)
        {
            //Initiates a jump request when requirements are met and enables double jump with jumping boots
            if (inventory.jumpingBoots != null && inventory.jumpingBoots.acquired)
            {
                if (isGrounded) jumpCount = 0;
                if (Input.GetButtonDown("Jump") && jumpCount < 1 && playerAttributes.currentStamina > jumpStaminaCost && (!onIce || inventory.cats.acquired))
                {
                    jumpRequest = true;
                    jumpCount++;
                }
            }

            else 
            {
                if (Input.GetButtonDown("Jump") && isGrounded && playerAttributes.currentStamina > jumpStaminaCost && (!onIce || inventory.cats.acquired)) jumpRequest = true;
            }

            if (Input.GetButton("Crouch")) Crouch();

            //Solves problems when crouching under a collider
            else
            {
                if (!Physics.Raycast(startPos, Vector3.up, length)) UnCrouch();
                else underCollider = true;
                if (underCollider && !Physics.Raycast(startPos, Vector3.up, length))
                {

                    UnCrouch();
                    underCollider = false;
                }
            }


            //Ice slide
            if (!onIce || inventory.cats.acquired)
            {
                float xNew = Input.GetAxis("Horizontal");
                float zNew = Input.GetAxis("Vertical");
                Vector3 transformRightNew = transform.right;
                Vector3 transformForwardNew = transform.forward;

                x = xNew;
                z = zNew;
                transformForward = transformForwardNew;
                transformRight = transformRightNew;
            }        
            else
            {
                print(x);
                print(z);
                if (Math.Abs(x) + Math.Abs(z) < 0.3)
                {
                    x = 0;
                    z = 1;              
                }
            
            }

            //Main move function which moves the player in a desired diretion
            Vector3 move = transformRight * x + transformForward * z;
            if(move.x > 1) move.x = 1;
            if(move.y > 1) move.y = 1;
            if(move.z > 1) move.z = 1;
            if(move.x < -1) move.x = -1;
            if(move.y < -1) move.y = -1;
            if(move.z < -1) move.z = -1;
            controller.Move(move * speed * Time.deltaTime);

            //Makes player move faster when sprint key is pushed and all requirements are met
            if (!onIce) 
            {
                if (Input.GetButton("Sprint") && isGrounded && playerAttributes.currentStamina >= 0.5f && move != Vector3.zero)
                {
                    if (isCrouched) UnCrouch();
                    speed = Mathf.MoveTowards(speed, defaultSpeed * 1.5f, Time.deltaTime / 0.2f);
                    isSprinting = true;
                }
                else if (!Input.GetButton("Sprint") || playerAttributes.currentStamina >= 0)
                {
                    speed = Mathf.MoveTowards(speed, defaultSpeed, Time.deltaTime / 0.2f);
                    isSprinting = false;
                }
            }
        }
       

        //Pushes player down when on an angles surface
        if ((x != 0 || z != 0) && OnSlope()) 
        {
            controller.Move(Vector3.down * controller.height / 2 * slopeForce * Time.deltaTime);
        }

        //Resets gravity when player is grounded
        if (!isGrounded && Physics.Raycast(startPos, Vector3.up, length) && gravityReset) 
        {
            velocity.y = gravity * Time.deltaTime;
            gravityReset = false;
        }     
        if(isGrounded) gravityReset = true;

        //Gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


       
    }

    void FixedUpdate()
    {
        //Ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0) velocity.y = -2f;

        //Jump on jump request and modify stamina
        if (jumpRequest && playerAttributes.currentStamina > jumpStaminaCost)
        {
            velocity.y = (float)Math.Sqrt(jumpHeight * -2f * gravity);
            playerAttributes.ModifyStamina(-jumpStaminaCost);
            jumpRequest = false;
        }

        //Modify stamina when sprinting
        if (isSprinting && !onIce) 
        {
            playerAttributes.ModifyStamina(-0.5f);
        }  
    }

    //Dertermines whether the player is on and angles surface or not
    private bool OnSlope() 
    {
        if (!isGrounded) return false;

        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, controller.height / 2 * slopeForceRayLenght)) 
        {
            if (hit.normal != Vector3.up) return true;
        }

        return false;
    }

    //Makes the player model taller again
    void UnCrouch() 
    {
        
        if (!isSprinting) speed = defaultSpeed;
        isCrouched = false;
        controller.height = Mathf.MoveTowards(controller.height, originalHeight, Time.deltaTime / crouchTime);
        Vector3 scale = model.localScale;
        scale.y = Mathf.MoveTowards(controller.height, originalHeight, Time.deltaTime / crouchTime) * 0.5f;
        model.localScale = scale;
    }

    //Makes the player model shorter and movement speed slower
    void Crouch()
    {
        speed = defaultSpeed * 0.5f;
        isCrouched = true;
        controller.height = Mathf.MoveTowards(controller.height, reducedHeight, Time.deltaTime / crouchTime);
        Vector3 scale = model.localScale;
        scale.y = Mathf.MoveTowards(controller.height, reducedHeight, Time.deltaTime / crouchTime) * 0.5f;
        model.localScale = scale;
    }

}
