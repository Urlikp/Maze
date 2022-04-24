using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    PlayerMovement playerMovement;
    MouseLook mouseLook;
    public Text endText;
    public GameObject health;
    public GameObject stamina;
    public GameObject inv;
    bool end;
    byte alpha = 0;
    int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        mouseLook = GameObject.Find("Main Camera").GetComponent<MouseLook>();
    }

    //When player enters end game trigger disables UI and controls and after 10 seconsds returns player to main menu
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
             playerMovement.enabled = false;
             mouseLook.enabled = false;
             end = true;
             health.SetActive(false);
             stamina.SetActive(false);
             inv.SetActive(false);
            StartCoroutine(WaitAndReturnToMenu());
        }
    }

    //Makes end game text visible
    void FixedUpdate()
    {
        if(end)
        {
            counter++;
            if(alpha < 255 && counter == 10)
            {
                counter = 0;
                alpha += 1;
            }
            endText.color = new Color32(255, 255, 255, alpha);

        }
    }

    IEnumerator WaitAndReturnToMenu()
    {
        yield return new WaitForSeconds(10);
        //return to main menu
        SceneManager.LoadScene("Menu");
        Cursor.lockState = CursorLockMode.None;
    }
}
