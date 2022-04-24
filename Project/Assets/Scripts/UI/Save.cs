using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save
{    
    //Save data structure
    public Color32[] invColors;
    public Vector3 playerPos;
    public Quaternion playerRot;
    public float playerHealth;
    public float playerStamina;
    public bool[,] items;
    public bool[] map;
    public List<bool> pickables;
    public List<int> icePlatforms;
    public bool[] torch;
    public bool hammer;
    public List<Vector3> fallingStonesPos;
    public List<Quaternion> fallingStonesRot;
    public List<int> desWalls;
    public List<int> desPillars;
    public bool collapsedCeiling;
    public List<bool> pillarCeilings;
    public List<Vector3> fallingCeilsPos;
    public List<Quaternion> fallingCeilsRot;

    public Save()
    {  
        playerPos = new Vector3();
        playerRot = new Quaternion();
        invColors = new Color32[8];
        items = new bool[11, 2];
        map = new bool[2];
        pickables = new List<bool>();
        icePlatforms = new List<int>();
        torch = new bool[2];
        desWalls = new List<int>();
        fallingStonesPos = new List<Vector3>();
        fallingStonesRot = new List<Quaternion>();
        desPillars = new List<int>();
        fallingCeilsPos = new List<Vector3>();
        fallingCeilsRot = new List<Quaternion>();
    }
   
}
