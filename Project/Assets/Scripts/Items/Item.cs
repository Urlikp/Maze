using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public bool acquired;
    public bool collected;
    protected Inventory inventory;
    public int slotIndex;
    public int rotateX = 0;
    public int rotateY = 0;
    public int rotateZ = 0;

    void Start()
    {
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
        //ItemCollect();     
    }

    //Rotate the item on fixed update
    void FixedUpdate() 
    {
        transform.Rotate(rotateX, rotateY, rotateZ);
    }

    //Picks up item on collision with the player
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player")) 
        {
            ItemCollect();         
        }
    }

    //Checks which item player pickup up and determines where to put it in the inventory
    public void ItemCollect() 
    {
        if (name == "Torch")
        {
            AddToInventory(0);
        }
        else if (name == "Hammer")
        {
            AddToInventory(1);
        }
        else if (name == "Cats")
        {
            AddToInventory(2);
        }
        else if (name == "Periscope")
        {
            AddToInventory(3);
        }
        else if (name == "Boots")
        {
            AddToInventory(4);
        }
        else if (name == "BreathingGear")
        {
            AddToInventory(5);
        }
        else if (name == "Key")
        {
            AddToInventory(6);
        }
        acquired = false;
        collected = true;
        gameObject.SetActive(false);
    }

    //Adds an item to inventory to a specified index
    void AddToInventory(int slotIndex)
    {
        this.slotIndex = slotIndex;
        inventory.slots[slotIndex].GetComponent<Image>().color = new Color32(255, 255, 225, 100);
    }
}
