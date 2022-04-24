using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickablesSave : MonoBehaviour
{
    //Save delegate for pickables
    public Transform[] ts;

    void Start()
    {
        ts = gameObject.GetComponentsInChildren<Transform>();
    }
}
