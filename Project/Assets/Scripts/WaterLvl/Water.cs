using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Checks if player is in water
// Must be placed on water object
public class Water : MonoBehaviour
{
    Transform drownCheck;
    Transform swimCheck;
    PlayerMovement playerMovement;
    MouseLook mouseLook;
    //public PlayerAttributes playerAttributes;
    Drowning drwn;

    public LayerMask waterMask;

    float oldSpeed;
    bool swimming;

    void Start()
    {
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        mouseLook = GameObject.Find("Main Camera").GetComponent<MouseLook>();
        swimCheck = GameObject.Find("SwimCheck").transform;
        drownCheck = GameObject.Find("DrownCheck").transform;
        drwn = GetComponent<Drowning>();
    }

    void Update()
    {
         if(!swimCheck){
             print("not swimming");
         }
         swimming = Physics.CheckSphere(swimCheck.position, 0.001f, waterMask);
         if(swimming)
         {
            //playerMovement.inWater = true;
            playerMovement.enabled = false;
            GameObject.Find("Player").GetComponent<Swimming>().enabled = true;

            //oldSpeed = playerMovement.defaultSpeed;
            if (!playerMovement.inventory.breathingGear.acquired)
            {          
                if(drwn.drowning = Physics.CheckSphere(drownCheck.position, 0.001f, waterMask)) playerMovement.isDrowning = true;
                else playerMovement.isDrowning = false;
            }

            else
            {
                if(Physics.CheckSphere(drownCheck.position, 0.001f, waterMask)) playerMovement.isDrowning = true;
                else playerMovement.isDrowning = false;
            }
            
         }
         else
         {
            drwn.drowning = false;
            playerMovement.inWater = false;
            playerMovement.enabled = true;
            GameObject.Find("Player").GetComponent<Swimming>().enabled = false;
         }
    }
}