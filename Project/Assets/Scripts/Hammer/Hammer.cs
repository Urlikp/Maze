using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public bool Equipped;
    public bool Swinging;

    // Start is called before the first frame update
    void Start()
    {
        Swinging = false;
    }

    private IEnumerator UpdateSwing()
    {

        yield return new WaitForSeconds(.1f);  // swing back (animation)
        Swinging = true;
        yield return new WaitForSeconds(.2f);  // swing forward 
        Swinging = false;
    }

    // Update is called once per frame
    void Update()
    {
        Animation animation = GetComponent<Animation>();

        if (Input.GetKey(KeyCode.Mouse0) && !animation.isPlaying)
        {
            //Debug.Log(animation.name);
            animation.Play();
            StartCoroutine("UpdateSwing");
        }
    }

}
