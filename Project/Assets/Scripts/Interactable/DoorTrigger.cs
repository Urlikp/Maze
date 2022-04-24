using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Animator anim;
    public GameObject wind;

    //Opens door and disables windtrap on trigger
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("Open");
            wind.SetActive(false);
        }
       
    }
}
