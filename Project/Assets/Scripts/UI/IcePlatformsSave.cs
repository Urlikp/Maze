using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePlatformsSave : MonoBehaviour
{
    //Save delegate for ice platforms
    public IcePlatform[] ics;

    void Start()
    {
        ics = gameObject.GetComponentsInChildren<IcePlatform>();
    }
}
