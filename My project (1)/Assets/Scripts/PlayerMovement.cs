using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 50.0f;
    public float jumpSpeed = 100.0f;
    public bool enableJump = false;
    public bool grounded = true;

    public float health = 3.0f;

    public GameObject parryBoxAnim;

    public Animator anim;

    public bool isInAir = false;
    // Start is called before the first frame update
    void Start()
    {  

    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        //x axis movement
        float xAxis = Input.GetAxis("Horizontal");
        if(xAxis != 0.0f)
        {
            Vector3 oldV = rb.velocity;
            oldV.x = 0.0f;
            Vector3 movement = new Vector3(xAxis, 0, 0) * speed + oldV;
            rb.velocity = movement;

            anim.SetBool("Walk", true);
            anim.ResetTrigger("Land");
        }
        else
        {
            anim.SetBool("Walk", false);
            anim.ResetTrigger("Land");
        }
        //Face the direction you are moving
        if(xAxis < 0)
        {
            Vector3 oldScale = transform.localScale;
            transform.localScale = new Vector3(oldScale.x, oldScale.y, Mathf.Abs(oldScale.z));
            parryBoxAnim.transform.localRotation = Quaternion.Euler(new Vector3(0f, -90f, 0f));
        }
        else if(xAxis > 0)
        {
            Vector3 oldScale = transform.localScale;
            transform.localScale = new Vector3(oldScale.x, oldScale.y, -Mathf.Abs(oldScale.z));
            parryBoxAnim.transform.localRotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));
        }
        //Jumps
        if(Input.GetKeyDown("w") && grounded)
        {
            Jump();
            anim.Play("Armature|PigeonJump");
            anim.ResetTrigger("Land");
        }
        //Double Jump
        else if(Input.GetKeyDown("w") && !grounded && enableJump)
        {
            Jump();
            anim.Rebind();
            anim.Play("Armature|PigeonJump");
            anim.ResetTrigger("Land");
            enableJump = false;
        }
        if((stateInfo.IsName("Armature|PigeonJump") || stateInfo.IsName("Armature|PigeonJumpAttack")) && stateInfo.normalizedTime > 0.5f)
        {
            RaycastHit hit;
            float raySize = 0.12f;
            Debug.Log("Ray Size" + raySize);
            //Check in air
            if(Physics.Raycast(transform.position, Vector3.down, out hit, raySize))
            {
                if(hit.transform.tag == "Floor")
                {
                    anim.SetTrigger("Land");
                }
            }
        }
    }
    void Jump()
    {
        Vector3 oldVelocity = rb.velocity;
        rb.velocity = new Vector3(oldVelocity.x, jumpSpeed, oldVelocity.z);
        grounded = false;
    }
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Floor")
        {
            grounded = true;
            enableJump = true;
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "EnemyBullet")
        {
            TakeDamage();
        }
    }
    void TakeDamage()
    {
        anim.Play("Armature|PigeonHurt");
        health -= 1.0f;
        if(health < 0.0f)
        {
            Invoke("Die", 0.5f);
        }
    }
    void Die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("GameOver");
    }
}
