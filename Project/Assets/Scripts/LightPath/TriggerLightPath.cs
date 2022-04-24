using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLightPath : MonoBehaviour
{
    //public int index = transform.GetSiblingIndex();
    public Light light;

    // Start is called before the first frame update
    void Start()
    {
        light = transform.parent.GetChild(1).GetComponent<Light>();
    }

    void OnTriggerEnter(Collider other)
    {
        light.DelegatedOnTriggerEnter(other);
    }
}
