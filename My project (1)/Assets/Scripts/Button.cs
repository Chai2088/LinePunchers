
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class Button : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
  {
 
    public int buttonIndex;
    private Vector3 size;
    void Start()
    {
        size = transform.localScale;
    }
    public void OnPointerEnter(PointerEventData eventData)
    { 
        transform.localScale = size * 1.2f;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = size;
    }



    public void OnButtonClick()
    { 

        // quit
        if(buttonIndex == 0)
        { 
            Debug.Log("quit");
            Application.Quit(); 
        }

        // resume
        if(buttonIndex == 1)
        {   
            Debug.Log("resume");
            Time.timeScale = 1f; 
        } 

        // play
        if(buttonIndex == 2)
        {   
            Debug.Log("play");
            SceneManager.LoadScene("SampleScene");
        } 

        // restart
        if(buttonIndex == 3)
        {   
            Debug.Log("restart");
            SceneManager.LoadScene("SampleScene");
        } 

        // main menu
        if(buttonIndex == 4)
        { 
            Debug.Log("menu");
            Application.Quit();
            SceneManager.LoadScene("MainMenu");
        }
    }

 

  }