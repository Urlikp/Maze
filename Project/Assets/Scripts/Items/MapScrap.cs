using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class MapScrap : Item
{
    public Texture texture;
    public Map map;
    public int index;

    //Picks up item on collision with the player
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            MapScrapCollect();
        }
    }

    //Adds map to inventory slot and adds texture to the Map class
    public void MapScrapCollect()
    {
        
        if (!map.collected) 
        {
            map.collected = true;
            inventory.slots[7].GetComponent<Image>().color = new Color32(255, 255, 225, 100);
            map.slotIndex = 7;
        }
        
        gameObject.SetActive(false);
        map.mapTextures[index] = texture;
        map.mapsCollected++;
        for (int i = 0; i < 4; i++) 
        {
            if (!map.mapScraps[i].acquired) map.mapScraps[i].index++;
        }
        
    }
}
