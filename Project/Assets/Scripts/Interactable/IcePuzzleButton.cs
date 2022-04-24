using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePuzzleButton : MonoBehaviour
{
    public Animator anim;
    public float timeout = 10f;
    // Start is called before the first frame update

    //When pushed lifts up pillars for a set duration
    public void Push()
    {
        Animator animator = gameObject.GetComponent<Animator>();
        animator.SetTrigger("Push");
        anim.SetTrigger("Move");
        StartCoroutine("WaitAndMoveDown");
    }

    IEnumerator WaitAndMoveDown() 
    {
        yield return new WaitForSeconds(timeout);
        anim.SetTrigger("Move");
    }

}
