using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button1Action : ButtonActionAbstract
{
    public GameObject pendulums;
    public Transform[] platforms;
    public GameObject Fireplace1Light;
    public GameObject Fireplace1Smoke;
    public GameObject Fireplace2Light;
    public GameObject Fireplace2Smoke;
    public BoxCollider FloorCollider;

    private bool _active = true;

    void Start()
    {
    }

    // starts collapsing bridge,  turns on indicating lights for second riddle
    public override void DoAction()
    {
        if (_active)
        {
            Animator animator = gameObject.GetComponent<Animator>();
            animator.SetTrigger("Push");

            _active = false;
            Debug.Log(this.name + " Pressed");
            foreach (PendulumSwing ps in pendulums.GetComponentsInChildren<PendulumSwing>())
            {
                ps.isEnabled = true;
            }
            Fireplace1Light.SetActive(true);
            Fireplace1Smoke.SetActive(true);
            Fireplace2Light.SetActive(true);
            Fireplace2Smoke.SetActive(true);
            FloorCollider.enabled = true;
            StartCoroutine("DestroyBridge");
        }
    }

    private IEnumerator DestroyBridge()
    {
        
        yield return new WaitForSeconds(2f);
        foreach (Transform x in platforms)
        {
            x.gameObject.SetActive(false);
            yield return new WaitForSeconds(1.5f);
        }
    }
}
