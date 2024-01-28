
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ButtonScale : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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
}
