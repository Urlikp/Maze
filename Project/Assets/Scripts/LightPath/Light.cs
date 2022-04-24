using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    // Start is called before the first frame update
    public int red = 0, green = 255, blue = 0; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void  DelegatedOnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Player"))
        {

            GetComponent<Renderer>().material.color = new Color(red, green, blue);        
        }
    }

}
