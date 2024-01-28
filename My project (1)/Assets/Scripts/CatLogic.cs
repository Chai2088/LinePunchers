using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatLogic : MonoBehaviour
{
    public GameObject catAttack;

    public GameObject[] PortalPos;

    public GameObject catHealth;
    public GameObject player;

    public Animator anim;
    public float attackDist = 5.0f;

    public ParticleSystem particle;
    bool animationPlayed = false;

    public float timer = 0.0f;

    public float visibleTimer = 0.0f;
    public float maxVisible = 7.0f;
    public Animator animFx;

    public bool enablePortal = false;
    public GameObject curPortal;
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
        if(enablePortal)
        {
            Animator PortalAnim = curPortal.GetComponent<Animator>();
            AnimatorStateInfo portalInfo = PortalAnim.GetCurrentAnimatorStateInfo(0);
            if(portalInfo.normalizedTime > 0.8f)
            {
                anim.Play("Armature|entry");
                enablePortal = false;
            }
            return;
        }
        //Check in exit
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        
        if(stateInfo.IsName("Armature|exit"))
        {
            timer += Time.deltaTime;
            if(timer > 5.0f)
            {
                int randomInt = Random.Range(0, PortalPos.Length);
                Vector3 portalPos = PortalPos[randomInt].transform.position;
                transform.position = portalPos + 0.5f * Vector3.down;
                curPortal = PortalPos[randomInt];
                PortalPos[randomInt].SetActive(true);
                enablePortal = true;
                timer = 0.0f;
            }
            else
            {
                catHealth.SetActive(false);
            }
            return;
        }
        else
        {
            visibleTimer += Time.deltaTime;
            if(visibleTimer > maxVisible)
            {
                anim.Play("Armature|exit");
                catHealth.SetActive(false);
                visibleTimer = 0.0f;
                return;
            }
        }

        float distance = Vector3.Distance(transform.position, player.transform.position);

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
                if(!(stateInfo.IsName("Armature|Attack01_001") || stateInfo.IsName("Armature|Zarpazo")))
                {
                    int randomInt = Random.Range(0, 2);
                    if(randomInt == 0)
                    {
                        anim.Play("Armature|Attack01_001");
                        animFx.Play("CatVertical");
                    }

                    else
                    {
                        animFx.Play("CatHorizontal");
                        anim.Play("Armature|Zarpazo");
                    }
                }
            } 
            else
            {
                catAttack.SetActive(false);
            }
        }
    }
}
