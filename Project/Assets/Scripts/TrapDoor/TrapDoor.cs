using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoor : MonoBehaviour
{
    private bool _enabled = true;

    // Wait for player to hit the trigger and then start the trapdoor animation
    public void DelegatedOnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (_enabled)
            {
                _enabled = false;
                GetComponent<Animation>().Play();
            }
        }
    }
}
