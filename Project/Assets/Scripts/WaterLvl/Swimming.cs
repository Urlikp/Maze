using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
// Player movement in water
// Script must be on Player

public class Swimming : MonoBehaviour
{
    //public bool _enabled = false;
    public float defaultSpeed = 7f;
    float x = 0;
    float y = 0;
    float z = 0;
    Vector3 transformRight;
    Vector3 transformForward;
    Vector3 transformUp;
    float speed;
    CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enabled){
            //print("plavu");
            float xNew = Input.GetAxis("Horizontal");
            float yNew = Input.GetAxis("Up");
            float zNew = Input.GetAxis("Vertical");

            Vector3 transformRightNew = transform.right;
            Vector3 transformForwardNew = transform.forward;
            Vector3 transformUpdNew = transform.up;

            x = xNew;
            y = yNew;
            z = zNew;
            transformForward = transformForwardNew;
            transformRight = transformRightNew;
            transformUp = transformUpdNew;

            Vector3 move = transformRight * x + transformForward * z + transformUp * y;
            controller.Move(move * defaultSpeed * Time.deltaTime);

        }
    }
}
