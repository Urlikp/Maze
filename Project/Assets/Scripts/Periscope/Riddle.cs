using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riddle : MonoBehaviour
{
    static int[] solution = {1,2,3};
    public int sequenceOrder;
    private static int[] input = {-1, -1, -1};

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
 
 
 /*function OnMouseDown() {
     input[0] = input[1];
     input[1] = input[2];
     input[2] = digit;
     
     if (solution[0] == input[0] && solution[1] == input[1] && solution[2] == input[2]) {
         Debug.Log("Correct Answer");
     }
 }*/