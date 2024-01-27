using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatLogic : MonoBehaviour
{
    public GameObject catAttack;
    public GameObject player;

    public Animator anim;
    public float attackDist = 5.0f;

    public ParticleSystem particle;
    bool animationPlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        particle = gameObject.GetComponent<ParticleSystem>();
        catAttack.SetActive(false);
        particle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        if(stateInfo.IsName("Armature|Attack01_001"))
        {
            if(stateInfo.normalizedTime > 0.3f)
            {
                catAttack.SetActive(true);
                if(!animationPlayed)
                {
                    particle.Play();
                    animationPlayed = true;
                }
            }
            if(stateInfo.normalizedTime > 0.6f)
            {
                catAttack.SetActive(false);
            }


        }
        else
        {
            animationPlayed = false;
        }
        if(!stateInfo.IsName("Armature|Parryhit01"))
        {
            if(distance < attackDist)
            {
                anim.SetTrigger("Attack");
            }
            else
            {
                anim.ResetTrigger("Attack");
                anim.SetTrigger("Idle");
                catAttack.SetActive(false);
            }
        }
    }
}
