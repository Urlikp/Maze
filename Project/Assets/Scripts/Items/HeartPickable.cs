using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickable : MonoBehaviour
{

    PlayerAttributes playerAttributes;

    void Start()
    {
        playerAttributes = GameObject.Find("Player").GetComponent<PlayerAttributes>();
    }

    //Rotate the item on fixed update
    void FixedUpdate()
    {
        transform.Rotate(0, 0, 1);
    }

    //Restore 25 health to the player on pickup
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player") && playerAttributes.currentHealth != 100)
        {
            playerAttributes.ModifyHealth(25);
            gameObject.SetActive(false);
        }
    }
}
