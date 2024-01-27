using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Animator anim;
    public float bulletSpeed;
    public Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Pop", 3.0f);
    } 
    
    // Update is called once per frame
    void Update()
    {
        transform.position += direction * bulletSpeed * Time.deltaTime;
        
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        if(stateInfo.IsName("Attack2Pop"))
        {
            if(stateInfo.normalizedTime > 0.9f)
                Die();
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Enemy bullet colliding");
        if (collision.gameObject.tag == "Player")
        {
            Pop();
        }
        else if(collision.gameObject.tag == "PlayerParry")
        {
            Debug.Log("Parry");
            Pop();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
    void Pop()
    {
        Invoke("Die", 1.0f);
        anim.Play("Attack2Pop");
    }

}
