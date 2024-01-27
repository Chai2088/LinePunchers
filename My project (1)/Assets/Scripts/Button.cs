
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class Button : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
  {
 
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
        //if (GUI.Button(new Rect(10, 10, 100, 30), "Change Scene"))
        { 
            SceneManager.LoadScene("SampleScene");
        }
    }

 

  }