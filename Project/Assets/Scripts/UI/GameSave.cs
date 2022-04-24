using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSave : MonoBehaviour
{
    Save save;
    public Transform player;
    PlayerAttributes playerAttributes;
    PlayerMovement playerMovement;
    Inventory inventory;
    public PickablesSave pickables;
    public IcePlatformsSave icePlatforms;
    public GameObject pendulumStack;
    public DesWallsSave desWalls;
    public DesWallsSave desPillars;
    public FallingStonesSave fallingStones;
    public GameObject stonesCeiling;
    public FallingStonesSave fallingCeils;

    public bool PassedCP = false;

    void Start()
    {
        save = new Save();
        playerAttributes = GameObject.Find("Player").GetComponent<PlayerAttributes>();
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
        //PassedCP = true;
    }

    //Saves player state
    void PlayerSave()
    {
        save.playerHealth = playerAttributes.currentHealth;
        save.playerStamina = playerAttributes.currentStamina;
        save.playerPos = player.position;
        save.playerRot = player.rotation;       
    }

    //Saves inevntory state
    void InventorySave()
    {
        for (int i = 0; i < 8; i++)
        {
            save.invColors[i] = inventory.slots[i].GetComponent<Image>().color;
        }
        ItemSave(0, inventory.torch);
        ItemSave(1, inventory.cats);
        ItemSave(2, inventory.hammer);
        ItemSave(3, inventory.periscope);
        ItemSave(4, inventory.jumpingBoots);
        ItemSave(5, inventory.breathingGear);
        ItemSave(6, inventory.key);
        ItemSave(7, inventory.map.mapScraps[0]);
        ItemSave(8, inventory.map.mapScraps[1]);
        ItemSave(9, inventory.map.mapScraps[2]);
        ItemSave(10, inventory.map.mapScraps[3]);
        save.map[0] = inventory.map.collected;
        save.map[1] = inventory.map.acquired;
        save.torch[0] = GameObject.Find("TorchObject").GetComponent<Torch>().torchLight.activeSelf;
         print(save.torch[0]);
        save.torch[1] = GameObject.Find("TorchObject").GetComponent<Torch>()._extinguished;
        save.hammer = GameObject.Find("HammerWrapper").GetComponent<HammerEquip>().hammer.transform.gameObject.activeSelf;
    }

    //Saves item state
    void ItemSave(int index, Item item)
    {
        save.items[index, 0] = item.collected;
        save.items[index, 1] = item.acquired;
    }

    //Saves pickables states
    void PickablesSave()
    {
        for (int i = 1; i < pickables.ts.Length; i++)
        {    
            save.pickables.Add(pickables.ts[i].gameObject.activeSelf);
        }
    }

    //Saves ice platforms states
    void IcePlatformsSave()
    {
        for (int i = 1; i < icePlatforms.ics.Length; i++)
        {    
            int stage = 0;
            if(icePlatforms.ics[i].undamaged.activeSelf) stage = 0;
            else if(icePlatforms.ics[i].damaged.activeSelf) stage = 1;
            else if(!icePlatforms.ics[i].gameObject.activeSelf) stage = 2;
            save.icePlatforms.Add(stage);
        }
    }

    //Saves destroyable walls and pillars states
    void DesWallsAndPillarsSave()
    {
        for (int i = 1; i < desWalls.walls.Length; i++)
        {    
            save.desWalls.Add(desWalls.walls[i].Hits);
        }

        for (int i = 1; i < desPillars.walls.Length - 1; i++)
        {    
            save.desPillars.Add(desPillars.walls[i].Hits);
        }
    }

    //Saves falling stones and celilings states
    void FallingStonesSave()
    {
        save.collapsedCeiling = stonesCeiling.activeSelf;
        for (int i = 1; i < fallingStones.stones.Length; i++)
        {         
            save.fallingStonesPos.Add(fallingStones.stones[i].position);
            save.fallingStonesRot.Add(fallingStones.stones[i].rotation);
        }

        for (int i = 1; i < fallingCeils.stones.Length - 1; i++)
        {         
            save.fallingCeilsPos.Add(fallingCeils.stones[i].position);
            save.fallingCeilsRot.Add(fallingCeils.stones[i].rotation);
        }
    }

    //Loads player state
    void PlayerLoad()
    {
        playerAttributes.SetHealth(save.playerHealth);
        playerAttributes.SetStamina(save.playerStamina);
        player.position = save.playerPos;
        player.rotation = save.playerRot;     
        playerMovement.isDrowning = false;  
    }

    //Loads inventory state
    void InventoryLoad()
    {
        for (int i = 0; i < 8; i++)
        {
            inventory.slots[i].GetComponent<Image>().color = save.invColors[i];
        }
        ItemLoad(0, inventory.torch);
        ItemLoad(1, inventory.cats);
        ItemLoad(2, inventory.hammer);
        ItemLoad(3, inventory.periscope);
        ItemLoad(4, inventory.jumpingBoots);
        ItemLoad(5, inventory.breathingGear);
        ItemLoad(6, inventory.key);
        inventory.map.collected = save.map[0];
        inventory.map.acquired = save.map[1];
        inventory.map.gameObject.SetActive(save.map[1]);
        if(inventory.map.collected) inventory.SetMapToggle(inventory.map);
        inventory.map.mapsCollected = 0;
        inventory.map.mapIndex = 0;
        for (int i = 0; i < 4; i++)
        {
           inventory.map.mapTextures[i] = inventory.map.defaultTexture;
        }
        inventory.map.mapScraps[0].index = 0;
        inventory.map.mapScraps[1].index = 0;
        inventory.map.mapScraps[2].index = 0;
        inventory.map.mapScraps[3].index = 0;
        MapScrapLoad(7, inventory.map.mapScraps[0]);
        MapScrapLoad(8, inventory.map.mapScraps[1]);
        MapScrapLoad(9, inventory.map.mapScraps[2]);
        MapScrapLoad(10, inventory.map.mapScraps[3]);
        Torch torch = GameObject.Find("TorchObject").GetComponent<Torch>();
        if (save.torch[1]) torch.Extinguish();
        else torch.Ignite();
        torch.torchLight.SetActive(save.torch[0]);
        GameObject.Find("HammerWrapper").GetComponent<HammerEquip>().hammer.transform.gameObject.SetActive(save.hammer);
    }

    //Loads item state
    void ItemLoad(int index, Item item)
    {
        item.collected = save.items[index, 0];
        if(!item.collected) item.gameObject.SetActive(true);
        else item.ItemCollect();
        item.acquired = save.items[index, 1];   
        if(item.collected) inventory.SetItemToggle(item);
    }


    //Loads map scrap state
    void MapScrapLoad(int index, MapScrap item)
    {
        item.collected = save.items[index, 0];
        if(!item.collected) item.gameObject.SetActive(true);
        else item.MapScrapCollect();
    }

    //Loads pickables states
    void PickablesLoad()
    {
        print(pickables.ts.Length);
        for (int i = 1; i < pickables.ts.Length; i++)
        {
            print(i);
            pickables.ts[i].gameObject.SetActive(save.pickables[i]);
        }
    }

    //Loads ice platforms states
    void IcePlatformsLoad()
    {
        for (int i = 1; i < icePlatforms.ics.Length; i++)
        {    
            if(save.icePlatforms[i] == 0)
            {
                icePlatforms.ics[i].triggerCount = 0;
                icePlatforms.ics[i].gameObject.SetActive(true);
                icePlatforms.ics[i].undamaged.SetActive(true);
                icePlatforms.ics[i].damaged.SetActive(false);               
            }
            else if(save.icePlatforms[i] == 1)
            {
                icePlatforms.ics[i].triggerCount = 1;
                icePlatforms.ics[i].gameObject.SetActive(true);
                icePlatforms.ics[i].undamaged.SetActive(false);
                icePlatforms.ics[i].damaged.SetActive(true);               
            }
            else if(save.icePlatforms[i] == 2)
            {
                icePlatforms.ics[i].triggerCount = 2;              
                icePlatforms.ics[i].undamaged.SetActive(false);
                icePlatforms.ics[i].damaged.SetActive(false);       
                icePlatforms.ics[i].gameObject.SetActive(false);        
            }
        }
    }

    //Loads destroyable walls and pillars states
    void DesWallsAndPillarsLoad()
    {
        for (int i = 1; i < desWalls.walls.Length; i++)
        {    
            desWalls.walls[i].Hits = save.desWalls[i];
            desWalls.walls[i].gameObject.SetActive(true);
            if(save.desWalls[i] == 0) desWalls.walls[i].gameObject.GetComponent<MeshRenderer>().material = desWalls.walls[i].MatUndamaged;
            else if(save.desWalls[i] == 1) desWalls.walls[i].gameObject.GetComponent<MeshRenderer>().material = desWalls.walls[i].Mat1Hit;
            else if(save.desWalls[i] == 2) desWalls.walls[i].gameObject.GetComponent<MeshRenderer>().material = desWalls.walls[i].Mat2Hits;
            else if(save.desWalls[i] == 3) desWalls.walls[i].gameObject.SetActive(false);
        }

        for (int i = 1; i < desPillars.walls.Length; i++)
        {    
            desPillars.walls[i].Hits = save.desPillars[i];
            desPillars.walls[i].gameObject.SetActive(true);
            if(save.desPillars[i] == 3) desPillars.walls[i].gameObject.SetActive(false);
        }
    }

    //Loads falling stones states
    void FallingStonesLoad()
    {
        stonesCeiling.SetActive(save.collapsedCeiling);
        for (int i = 1; i < fallingStones.stones.Length; i++)
        {    
            fallingStones.stones[i].position = save.fallingStonesPos[i];
            fallingStones.stones[i].rotation = save.fallingStonesRot[i];
            if(save.collapsedCeiling)
            {
                fallingStones.stones[i].gameObject.GetComponent<Rigidbody>().isKinematic = true;
                fallingStones.stones[i].gameObject.GetComponent<DamageOnContact>().enabled = false;
            }
        }

        for (int i = 1; i < fallingCeils.stones.Length - 1; i++)
        {    
            fallingCeils.stones[i].position = save.fallingCeilsPos[i];
            fallingCeils.stones[i].rotation = save.fallingCeilsRot[i];
            fallingCeils.stones[i].gameObject.GetComponent<Rigidbody>().isKinematic = true;
            fallingCeils.stones[i].gameObject.GetComponent<DamageOnContact>().enabled = false;
        }
    }

    public void Save()
    {   
        PlayerSave();
        InventorySave();
        PickablesSave();
        IcePlatformsSave();
        DesWallsAndPillarsSave();
        FallingStonesSave();
    }

    public void Load()
    {
        if (!PassedCP)
        {
            return;
        }
        
        PlayerLoad();
        InventoryLoad();
        PickablesLoad();
        IcePlatformsLoad();
        DesWallsAndPillarsLoad();
        FallingStonesLoad();
    }
   
}
