using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class IcePlatform : Ice
{
    public GameObject undamaged;
    public GameObject damaged;
    public float triggerCount = 0;

    //Sitches models depending on the number of time the player has entered the trigger
    public void OnTriggerEnter(Collider collider)
    {
        IceEnter(collider);
        triggerCount++;
        if (triggerCount == 1) 
        {
            undamaged.SetActive(false);
            damaged.SetActive(true);
        }
        if (triggerCount >= 2)
        {
            StartCoroutine("WaitAndDestroy");
        }
    }

    public void OnTriggerExit(Collider collider)
    {
        IceExit(collider);
        if (triggerCount >= 2)
        {         
           gameObject.SetActive(false);
        }
    }

    IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(1f);
        damaged.SetActive(false);
    }
}
