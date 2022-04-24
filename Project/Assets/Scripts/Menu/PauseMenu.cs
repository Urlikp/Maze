using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{

    public static bool GamePaused = false;
    public GameObject UI;
    public GameObject PauseMenuUI;
    [Tooltip("Automatically fetched")]
    public PlayerMovement PMovement;
    [Tooltip("Automatically fetched")]
    public MouseLook MLook;
    public string MainSceneName = "Menu";
    public GameSave GSave;
    public GameObject LoadLastCP;
    public GameObject Controls;


    private bool _loadLast = false;
    public bool once = false;

    void Start()
    {
        
        if (PMovement == null)
        {
            PMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        }
        if (MLook == null)
        {
            MLook = GameObject.Find("Player").GetComponentInChildren<MouseLook>();
        }
        if (LoadLastCP == null)
        {
            LoadLastCP = transform.Find("PauseMenuUI").transform.Find("LoadLastCheckpoint").gameObject;
        }
        if (Controls == null)
        {
            Controls = transform.Find("Controls").gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (_loadLast)
        {
            Load();
            if (once)
            {
                StartCoroutine(resetLast());
                once = false;
            }
        }
    }

    public void Pause()
    {
        GamePaused = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        PauseMenuUI.SetActive(true);
        Debug.Log(GSave.PassedCP);
        if (GSave.PassedCP)
        {
            LoadLastCP.SetActive(true);
        } else
        {
            LoadLastCP.SetActive(false);
        }
        UI.SetActive(false);
        PMovement.inputEnabled = false;
        MLook.inputEnabled = false;
        
    }

    public void Resume()
    {
        GamePaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        PauseMenuUI.SetActive(false);
        UI.SetActive(true);
        PMovement.inputEnabled = true;
        MLook.inputEnabled = true;
        Controls.SetActive(false);
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(MainSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadLast()
    {
        Resume();
        once = true;
        _loadLast = true;
    }

    IEnumerator resetLast()
    {
        yield return new WaitForSeconds(2f);
        _loadLast = false;
    }

    void Load()
    {
        PMovement.enabled = false;
        GSave.Load();
        PMovement.enabled = true;
    }
}
