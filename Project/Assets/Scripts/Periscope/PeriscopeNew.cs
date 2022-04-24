using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeriscopeNew : MonoBehaviour
 {
 
     public Transform Player;
     public Camera FirstPersonCam, ThirdPersonCam;
     public KeyCode TKey = KeyCode.Alpha4;
     public bool camSwitch = false;
 
    void Start(){
        FirstPersonCam.gameObject.SetActive(true);
        ThirdPersonCam.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(TKey))
        {
            camSwitch = !camSwitch;
            FirstPersonCam.gameObject.SetActive(camSwitch);
            ThirdPersonCam.gameObject.SetActive(!camSwitch);
        }
    }
 }
