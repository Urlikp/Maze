using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StonesCheck : MonoBehaviour
{
    public GameObject Fireplace1Light;
    public GameObject Fireplace1Smoke;
    public GameObject Fireplace2Light;
    public GameObject Fireplace2Smoke;

    public GameObject Stones;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        // gets array of all active stones. If no stones are left, light the fireplaces
        Transform[] stonesTransArr = Stones.GetComponentsInChildren<Transform>(false);
        if (stonesTransArr.Length > 1)
        {
            /*
            Debug.Log("Some stones are left");
            foreach (Transform stone in stonesTransArr)
            {
                Debug.Log(stone.gameObject.name);
            }
            */
            return;
        }
        Debug.Log("No stones left");

        Fireplace1Light.SetActive(true);
        Fireplace1Smoke.SetActive(true);
        Fireplace2Light.SetActive(true);
        Fireplace2Smoke.SetActive(true);
    }

}
