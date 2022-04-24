using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneButton : MonoBehaviour
{
    public GameObject[] doors;

    //Opens assigned set of doors when pushed
    public void Push()
    {
        Animator animator = gameObject.GetComponent<Animator>();
        animator.SetTrigger("Push");
        StartCoroutine(WaitForAnim());     
       
    }

    IEnumerator WaitForAnim() 
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < doors.Length; i++)
        {
            Animator doorAnim = doors[i].GetComponent<Animator>();
            doorAnim.SetTrigger("Open");
        }
       
    }
}
