using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("This class is obsolete. Use InteractableController1 instead.")]
public class Button : MonoBehaviour
{
    public ButtonActionAbstract action;
    private bool _isActive;

    private bool _lastState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updateColor();
        if (_isActive && Input.GetKeyDown(KeyCode.E))
        {
            action.DoAction();
        }
    }

    void updateColor()
    {
        bool currentState = _isActive;
        if (currentState != _lastState)
        {
            GameObject indicator = transform.Find("Indicator").gameObject;
            if (currentState == true)
            {
                indicator.GetComponent<Renderer>().material.color = Color.green;
            }
            else
            {
                indicator.GetComponent<Renderer>().material.color = Color.red;
            }

        }
        _lastState = currentState;
    }

    public void Enable()
    {
        _isActive = true;
    }

    public void Disable()
    {
        _isActive = false;
    }
}
