using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    // Start is called before the first frame update
    public Texture[] mapTextures;
    public Texture defaultTexture;
    public MapScrap[] mapScraps;
    public GameObject map;
    public Inventory inventory;
    public int slotIndex;

    public int mapIndex;
    public int mapsCollected;
    public Renderer m_Renderer;
    public bool acquired;
    public bool collected;

    //Sets start textures to blank
    void Start()
    {
        mapTextures = new Texture[4];
        m_Renderer = GetComponent<Renderer>();
        m_Renderer.material.SetTexture("_MainTex", mapTextures[0]);
        for (int i = 0; i < 4; i++)
        {
            mapTextures[i] = defaultTexture;
        }
        map.SetActive(false);
    }


    //Depending on how many maps player has collected cycle trough them
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.PageUp))
        {
            mapIndex++;
            if (mapIndex == mapsCollected) mapIndex = 0;
            m_Renderer.material.SetTexture("_MainTex", mapTextures[mapIndex]);
        }
        else if (Input.GetKeyDown(KeyCode.PageDown))
        {
            mapIndex--;
            if (mapIndex < 0) mapIndex = mapsCollected - 1;
            m_Renderer.material.SetTexture("_MainTex", mapTextures[mapIndex]);
        }
    }
}
