using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPedistal : MonoBehaviour
{
    public ParticleSystem fire;
    public ParticleSystem smoke;
    public GameObject pointLight;
    public bool collected;
    public Item item;
    public ItemPedistals itemPedistals;

    //Counts the number of collected main items
    void Update()
    {
        collected = item.collected;
        if (collected) 
        {
            itemPedistals.itemsCollected++;
            enabled = false;
        }
       
    }
}
