using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public Button resumeButton;
    public Button restartButton;
    public Button quitButton;
    // Start is called before the first frame update
    void Start()
    {
        SetPauseMenuActive(false);
 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            TogglePauseMenu();
        }
    }

    void TogglePauseMenu()
    {
        bool isPaused = !pauseMenuUI.activeSelf;


        Time.timeScale = isPaused ? 0f : 1f;
        SetPauseMenuActive(isPaused);
    }

    void SetPauseMenuActive(bool isActive){
        pauseMenuUI.SetActive(isActive);
    }

    void ResumeGame()
    {
        TogglePauseMenu();
    }
    void RestartGame()
    {

    }
    void QuitGame()
    {

    }
}
