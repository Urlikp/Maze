using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageMove : MonoBehaviour
{
    public CharacterController characterController;
    public PlayerAttributes playerAttributes;
    Vector3 move;
    public float force = 7f;
    bool contact = false;
    public float duration = 1f;
    float time = 0f;
    float damageTime = 0f;
    public float damageCooldown = 0.5f;
    bool damageTaken = false;
    public float pendulumDamage;
    public float spikesDamage;
    public float staticSpikesDamage;

    //Gets the point of contact with a trap and pushed the player in that direction  witha specified force
    void OnCollisionEnter(Collision collision)
    {
        if (!contact)
        {
            ContactPoint contactPoint = collision.contacts[0];
            move = characterController.transform.position - contactPoint.point;
            contact = true;
            move.y = 0.5f;
            if (collision.gameObject.tag == "Trap")
            {
                if (!damageTaken)
                {
                    damageTaken = true;
                    switch (collision.gameObject.name)
                    {
                        case "Pendulum":
                            playerAttributes.ModifyHealth(-pendulumDamage);
                            break;
                        case "Spikes":
                            playerAttributes.ModifyHealth(-spikesDamage);
                            break;
                        case "StaticSpikes":
                            playerAttributes.ModifyHealth(-staticSpikesDamage);
                            break;
                        default:
                            break;
                    }

                }
            }
        }
    }

    void FixedUpdate()
    {
        if (damageTaken && damageTime < damageCooldown)
        {
            damageTime += Time.deltaTime;
            if (damageTime >= damageCooldown)
            {
                damageTaken = false;
                damageTime = 0;
            }

        }
        if (contact && time < duration)
        {
            characterController.Move(move * force * Time.deltaTime);
            time += Time.deltaTime;
            if (time >= duration)
            {
                contact = false;
                time = 0;
            }
        }

    }
}
