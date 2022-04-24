using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPedistals : MonoBehaviour
{
    public int itemsCollected;
    public ItemPedistal[] itemPedistals;
    public Animator door1;
    public Animator door2;

    //Makes it so the player can only pickup 3 items from the main hub and opens the side doors
    void Update()
    {
        if (itemsCollected == 3) 
        {
            for (int i = 0; i < 4; i++) 
            {
                if (!itemPedistals[i].collected) 
                {
                    itemPedistals[i].smoke.Play();
                    itemPedistals[i].fire.Play();
                    itemPedistals[i].pointLight.SetActive(true);
                    itemPedistals[i].item.gameObject.SetActive(false);
                    door1.SetTrigger("Open");
                    door2.SetTrigger("Open");
                    break;
                }
            }
            enabled = false;
        }
    }
}
