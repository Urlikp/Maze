using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Item cats;
    public Item hammer;
    public Item breathingGear;
    public Item torch;
    public Item periscope;
    public Item key;
    public Map map;
    public Item jumpingBoots;

    public Image[] slots;

    Torch torchLight;

    void Start()
    {
        torchLight = GameObject.Find("TorchObject").GetComponent<Torch>();
    }

    //Toggles specified item
    public void ItemToggle(Item item) 
    {
        if (item.acquired)
        {
            slots[item.slotIndex].GetComponent<Image>().color = new Color32(255, 255, 225, 100);
            item.acquired = false;
        }
        else
        {
            slots[item.slotIndex].GetComponent<Image>().color = new Color32(255, 255, 225, 255);
            item.acquired = true;
        }
    }

    //Toggles map
    public void MapToggle(Map item)
    {
        if (item.acquired)
        {
            slots[item.slotIndex].GetComponent<Image>().color = new Color32(255, 255, 225, 100);
            item.acquired = false;
        }
        else
        {
            slots[item.slotIndex].GetComponent<Image>().color = new Color32(255, 255, 225, 255);
            item.acquired = true;
        }
    }

    
    public void SetItemToggle(Item item) 
    {
        if (item.acquired)
        {
            slots[item.slotIndex].GetComponent<Image>().color = new Color32(255, 255, 225, 255);
            item.acquired = true;
        }
        else
        {
            slots[item.slotIndex].GetComponent<Image>().color = new Color32(255, 255, 225, 100);
            item.acquired = false;
          
        }
    }

    public void SetMapToggle(Map item)
    {
        if (item.acquired)
        {
            slots[item.slotIndex].GetComponent<Image>().color = new Color32(255, 255, 225, 255);
            item.acquired = true;
        }
        else
        {
           
            slots[item.slotIndex].GetComponent<Image>().color = new Color32(255, 255, 225, 100);
            item.acquired = false;
        }
    }

    //Item toggling on button down
    void Update()
    {
        if (Input.GetButtonDown("Boots") && jumpingBoots != null && jumpingBoots.collected)
        {
            ItemToggle(jumpingBoots);
        }

        if (Input.GetButtonDown("Cats") && cats != null && cats.collected)
        {
            ItemToggle(cats);
        }

        if (Input.GetButtonDown("Torch") && torch != null && torch.collected)
        {
            ItemToggle(torch);
            torchLight.SetTorchLight();
        }

        if (Input.GetButtonDown("Breathing Gear") && breathingGear != null && breathingGear.collected)
        {
            ItemToggle(breathingGear);

        }

        if (Input.GetButtonDown("Hammer") && hammer != null && hammer.collected)
        {
            ItemToggle(hammer);
        }

        if (Input.GetButtonDown("Periscope") && periscope != null && periscope.collected)
        {
            ItemToggle(periscope);
        }

        if (Input.GetButtonDown("Map") && map != null && map.collected)
        {
            MapToggle(map);
        }

        if (Input.GetButtonDown("Key") && key != null && key.collected)
        {
            ItemToggle(key);
        }
    }
}
