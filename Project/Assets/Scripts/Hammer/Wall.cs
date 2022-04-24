using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public int Hits = 0;

    public Material MatUndamaged;
    public Material Mat1Hit;
    public Material Mat2Hits;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Hammer"))
        {
            // prevent detection of bumping without swinging
            Hammer hammer = other.GetComponentInParent<Hammer>();
            if (hammer == null)
            {
                Debug.Log("Hammer does not have \"Hammer\" script");
                return;
            }
            if (!hammer.Swinging) 
                return;
            hammer.Swinging = false;
            Hits++;
            switch (Hits)
            {
                case 0:
                    try
                    {
                        gameObject.GetComponent<MeshRenderer>().material = MatUndamaged;
                    }
                    catch { }
                    break;
                case 1:
                    try
                    {
                        gameObject.GetComponent<MeshRenderer>().material = Mat1Hit;
                    }
                    catch { }
                    break;
                case 2:
                    try
                    {
                        gameObject.GetComponent<MeshRenderer>().material = Mat2Hits;
                    }
                    catch { }
                    break;
                case 3:
                    gameObject.SetActive(false);
                    break;
                default:
                    Debug.Log("invalid hits");
                    try
                    {
                        gameObject.GetComponent<MeshRenderer>().material = MatUndamaged;
                    }
                    catch { }
                    break;
            }
        }
    }
}
