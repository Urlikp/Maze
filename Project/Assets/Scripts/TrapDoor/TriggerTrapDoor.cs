using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTrapDoor : MonoBehaviour
{
    public TrapDoor parentTrapDoor;

    // Set some variables
    void Start()
    {
        parentTrapDoor = transform.parent.GetComponent<TrapDoor>();
    }

    // Call parent method
    void OnTriggerEnter(Collider other)
    {
        parentTrapDoor.DelegatedOnTriggerEnter(other);
    }
}
