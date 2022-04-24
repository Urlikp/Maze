using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour
{
    GameSave gameSave;
    Text saveText;

    void Start()
    {
        gameSave = GameObject.Find("Game").GetComponent<GameSave>();
        saveText = GameObject.Find("SaveText").GetComponent<Text>();
    }

    //Saves game and disables itself on trigger
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            gameSave.Save();
            saveText.color = new Color32(255,255,255,255);
            StartCoroutine(WaitAndDeactivate());
            gameSave.PassedCP = true;
        }
       
    }
    
    IEnumerator WaitAndDeactivate()
    {
        yield return new WaitForSeconds(2);
        saveText.color = new Color32(255,255,255,0);
        gameObject.SetActive(false);
    }
}
