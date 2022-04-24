using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    //When the player hasnt aquired cats yet, makes player slide in PlayerMovement class
    protected void IceEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            playerMovement.onIce = true;
            if (playerMovement.inventory.cats.acquired)
            {         
                playerMovement.defaultSpeed = playerMovement.reducedSpeed;
            } 
        }
    }

    protected void IceExit(Collider collider)
    {
        print("Exit");
        playerMovement.onIce = false;
        if (playerMovement.inventory.cats.collected) playerMovement.defaultSpeed = playerMovement.normalSpeed;
    }

    void OnTriggerEnter(Collider collider)
    {
        IceEnter(collider);
    }


    void OnTriggerExit(Collider other)
    {
        IceExit(other);
    }
}
