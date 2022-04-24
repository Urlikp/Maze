using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{

    public PlayerAttributes playerAttributes;

    void Start()
    {
        if (playerAttributes == null)
        {
            playerAttributes = GameObject.Find("Player").GetComponent<PlayerAttributes>();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerAttributes.ModifyHealth(-100);
        }

    }
}
