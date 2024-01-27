using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartUILogic : MonoBehaviour
{
    public Image heart1;
    public Image heart2;
    public Image heart3;

    public Sprite Heartoff1;
    public Sprite Heartoff2;
    public Sprite Heartoff3;

    public GameObject player;

    public float health;
    // Start is called before the first frame update
    void Start()
    {
        health = player.GetComponent<PlayerMovement>().health;
    }

    // Update is called once per frame
    void Update()
    {
        health = player.GetComponent<PlayerMovement>().health;
        if(health == 2.0f)
        {
            heart1.sprite = Heartoff1;
        }
        else if(health == 1.0f)
        {
            heart2.sprite = Heartoff2;
        }
        else if(health == 0.0f)
        {
            heart3.sprite = Heartoff3;
        }
    }
}
