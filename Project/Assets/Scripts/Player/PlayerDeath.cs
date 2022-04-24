using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    GameSave gameSave;
    PlayerAttributes playerAttributes;
    PlayerMovement playerMovement;
    PlayerDamageMove playerDamageMove;
    public MouseLook mouseLook;

    void Start()
    {
        playerAttributes = GetComponent<PlayerAttributes>();
        gameSave = GameObject.Find("Game").GetComponent<GameSave>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    //If players health goes to zero => Die
    void Update()
    {
        if(playerAttributes.currentHealth <= 0)
        {
            StartCoroutine(Die());
        }
    }

    //Locks the player controls and unlocks rigidbody constraints
    //Loads the game on the latest checkpoint and enables controls again
    IEnumerator Die()
    {
        Rigidbody rigidBody = gameObject.GetComponent<Rigidbody>();
        rigidBody.isKinematic = false;
        rigidBody.freezeRotation = false;
        rigidBody.constraints = RigidbodyConstraints.FreezeRotationY;
        mouseLook.enabled = false;
        playerMovement.inputEnabled = false;
        yield return new WaitForSeconds(1);
        gameSave.Load();
        rigidBody.isKinematic = true;
        rigidBody.freezeRotation = true;
        mouseLook.enabled = true;
        playerMovement.inputEnabled = true;
        
    }
}
