using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaPickable : MonoBehaviour
{
    // Start is called before the first frame update
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

    //Restore 25 stamina to the player on pickup
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player") && playerAttributes.currentStamina != 100)
        {
            playerAttributes.ModifyStamina(25);
            gameObject.SetActive(false);
        }
    }
}
