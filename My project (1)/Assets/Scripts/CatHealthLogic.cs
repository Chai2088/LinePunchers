using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatHealthLogic : MonoBehaviour
{
    public float health;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool("BlockInput", false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerBullet")
        {
            TakeDamage();
        }
    }
    void TakeDamage()
    {
        health -= 1.0f;
        if(health == 5.0f)
        {
            anim.Play("Armature|exit");
            return;
        }
        if(health < 0.0f)
        {

            anim.SetBool("BlockInput", true);
        }
    }
}
