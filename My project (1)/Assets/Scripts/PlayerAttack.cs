using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject attackBox;
    public GameObject parryBox;
    public bool onParry;

    public Animator anim;

    private AudioSource audioSource;
    public AudioClip Tickles;

    // Start is called before the first frame update
    void Start()
    {
        attackBox.SetActive(false);
        
        audioSource = GetComponent<AudioSource>();
    }

    void PlaySound(AudioClip soundClip)
    {
        // Play the specified sound clip
        audioSource.clip = soundClip;
        audioSource.Play();
    }
    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);

        if(Input.GetKey("f"))
        {
 
            attackBox.SetActive(true);
            if(stateInfo.IsName("Armature|PigeonJump") || stateInfo.IsName("Armature|PigeonJumpAttack"))
            {
                Debug.Log("AirAttack");
                anim.Play("Armature|PigeonJumpAttack");
            }
            else
            {
                anim.Play("Armature|PigeonAttack");
            }
            // Play the specified sound clip 
            PlaySound(Tickles);
             
        }
        else
        {
            attackBox.SetActive(false);
        }
        if(!stateInfo.IsName("Armature|PigeonJump") || stateInfo.IsName("Armature|PigeonJumpAttack"))
        {
            if(Input.GetKey("r"))
            {
                parryBox.SetActive(true);

                anim.Play("Armature|PigeonParry");
            }
            else
            {
                parryBox.SetActive(false);
            }
        }
    }
}
