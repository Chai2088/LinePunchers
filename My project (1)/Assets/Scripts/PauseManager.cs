using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        resumeButton.onClick.AddListener(ResumeGame);
        restartButton.onClick.AddListener(RestartGame);
        quitButton.onClick.AddListener(QuitGame);
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

        //Time.timeScale = isPaused 
    }
}
