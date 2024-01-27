using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject attackBox;
    public GameObject parryBox;
    public bool onParry;
    // Start is called before the first frame update
    void Start()
    {
        attackBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("f"))
        {
            attackBox.SetActive(true);
        }
        else
        {
            attackBox.SetActive(false);
        }
        if(Input.GetKey("r"))
        {
            parryBox.SetActive(true);
        }
        else
        {
            parryBox.SetActive(false);
        }
    }
}
