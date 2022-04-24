using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapseCeiling : MonoBehaviour
{
    public GameObject Ceiling;
    public GameObject[] Stones;

    void OnDisable()
    {
        Ceiling.SetActive(false);

        foreach (GameObject stone in Stones)
        {
            stone.GetComponent<Rigidbody>().isKinematic = false;
            stone.GetComponent<DamageOnContact>().enabled = true;
        }
    }
}
