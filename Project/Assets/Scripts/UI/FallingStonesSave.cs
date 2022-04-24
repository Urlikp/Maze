using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStonesSave : MonoBehaviour
{
    //Save delegate for falling stones
    public Transform[] stones;

    void Start()
    {
        stones = gameObject.GetComponentsInChildren<Transform>();
    }
}
