using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesWallsSave : MonoBehaviour
{
    //Save delegate for destroyable walls
    public Wall[] walls;

    void Start()
    {
        walls = gameObject.GetComponentsInChildren<Wall>();
    }
}
