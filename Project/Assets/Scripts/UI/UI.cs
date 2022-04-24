using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject mapObj;
    public Map map;

    //Equips and unequips map
    void Update()
    {

        if (Input.GetButtonDown("Map") && map.collected)
        {
            if(!mapObj.activeSelf)
            {
                mapObj.SetActive(true);
                map.m_Renderer.material.SetTexture("_MainTex", map.mapTextures[map.mapIndex]);
            }
            else mapObj.SetActive(false);
        }
    }
}
