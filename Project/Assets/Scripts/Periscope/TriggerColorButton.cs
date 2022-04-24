using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerColorButton : MonoBehaviour
{
    bool hasCollided = false;
    public ColorButton button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<ColorButton>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hasCollided){
            if(Input.GetKey(button.TKey)){
                GetComponent<Renderer>().material.color = new Color(button.red, button.green, button.blue);        
            }
        }
    }

    void OnGUI()
    {
        if (hasCollided == true)
        {
            GUI.Label(new Rect(Screen.width/2, Screen.height - 50, Screen.width/2 -20, 120), (button.labelText));
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Player has entered the button area");
            hasCollided = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        print("Player has exited the button area");
        hasCollided = false;
    }
}
