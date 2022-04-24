using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("This class is obsolete. Use InteractableController1 instead.")]
public class ButtonActive : MonoBehaviour
{
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            button.Enable();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            button.Disable();
        }
    }
}
