using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerEquip : MonoBehaviour
{
    public Hammer hammer;
    public Item ItemHammer;

    private bool _equipped;

    // Start is called before the first frame update
    void Start()
    {
        _equipped = false;
        hammer.transform.gameObject.SetActive(_equipped);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Hammer") && ItemHammer.collected)
        {
            _equipped = !_equipped;
            hammer.transform.gameObject.SetActive(_equipped);
            Debug.Log("Hammer eq " + _equipped.ToString());
        }
    }
}
