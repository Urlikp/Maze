using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Takes player's health if he is underwater and without breathing gear
public class Drowning : MonoBehaviour
{
    public float damage;

    public float damage_cooldown = .5f;

    public bool drowning = false;
    PlayerAttributes playerAttributes;

    // Start is called before the first frame update
    // Called by Water
    void Start()
    {
        playerAttributes = GameObject.Find("Player").GetComponent<PlayerAttributes>();
    }

    // Update is called once per frame
    void Update()
    {
        if(drowning){
            if(playerAttributes.currentStamina > 1){
                playerAttributes.ModifyStamina(-damage);
            }
            else{
                playerAttributes.ModifyHealth(-damage);

            }
        }
    }
}
