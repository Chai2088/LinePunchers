
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class Button : MonoBehaviour
  {
 
    public int buttonIndex;

    // Function for the second button
    public void Play()
    {
            Debug.Log("play");
            SceneManager.LoadScene("Level1");
    }

    // Function for the second button
    public void Resume()
    {
            Time.timeScale = 1f; 
    }


    // Function for the second button
    public void Quit()
    {
            Debug.Log("quit");
            Application.Quit(); 
    }
 
 
    // Function for the second button
    public void MainMenu()
    {
            SceneManager.LoadScene("MainMenu");
    }
 
 

  }