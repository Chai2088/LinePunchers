using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAttackLogic : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.ResetTrigger("Parry");
        anim.ResetTrigger("Attack");
        anim.SetTrigger("Idle");
    }
    void OnTriggerEnter(Collider other)
    {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        if(stateInfo.IsName("Armature|Parryhit01"))
            return;
        
        if(other.gameObject.tag == "PlayerParry")
        {
            anim.ResetTrigger("Attack");
            anim.SetTrigger("Parry");
            anim.SetTrigger("Idle");
            gameObject.SetActive(false);
        }
    }
}
