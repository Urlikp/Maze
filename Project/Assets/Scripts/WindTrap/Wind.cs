using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    Torch torch;

    // Set some variables
    void Start()
    {
        torch = GameObject.Find("TorchObject").GetComponent<Torch>();
    }

    // Wait for player to hit the trigger and then extinguish the torch
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            torch.Extinguish();
        }
    }
}
