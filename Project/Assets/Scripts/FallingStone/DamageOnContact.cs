using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnContact : MonoBehaviour
{
    public PlayerAttributes Attributes;
    public int damage;

    void Start()
    {
        Attributes = GameObject.Find("Player").GetComponent<PlayerAttributes>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Attributes.ModifyHealth(-damage);
        }
    }
    
}
