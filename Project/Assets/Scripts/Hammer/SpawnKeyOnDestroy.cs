using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKeyOnDestroy : MonoBehaviour
{
    public GameObject Key;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDisable()
    {
        Key.SetActive(true);
    }
}
