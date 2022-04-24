using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRiddleDoor : MonoBehaviour
{
    public GameObject doorLeft;
    public GameObject doorRight;

    Animator animLeft;
    Animator animRight;

    public int riddlesSolved = 0;

    //Opens large door in the main hub when 3 riddles are solved
    void Update()
    {
        if (riddlesSolved == 3) 
        {
            animLeft = doorLeft.GetComponent<Animator>();
            animRight = doorRight.GetComponent<Animator>();
            animLeft.SetTrigger("Open");
            animRight.SetTrigger("Open");
        }    
    }
}
