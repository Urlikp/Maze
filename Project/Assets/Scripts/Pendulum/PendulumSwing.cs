using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PendulumSwing : MonoBehaviour
{

    public float speed;
    public float maxAngle;
    public float angle;
    public bool isEnabled;

    public float startAngle;
    private float _time;
    private float _timeStart;

    private GameObject joint;

    // Start is called before the first frame update
    void Start()
    {
        _time = Mathf.Asin(startAngle/maxAngle)/speed;
        _timeStart = _time;
        joint = transform.Find("Joint").gameObject;
        updateAngle();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isEnabled)
        {
            _time += Time.deltaTime;
            _time = _time % (2 * Mathf.PI / speed);
            //Debug.Log(_time);
            updateAngle();
        }
        
    }

    void updateAngle()
    {

        this.angle = maxAngle * Mathf.Sin(_time * this.speed);
        joint.transform.localRotation = Quaternion.Euler(0, 0, angle);
    }
}
