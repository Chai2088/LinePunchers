using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public float bulletSpeed;
    public Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Die", 3.0f);
    } 
    
    // Update is called once per frame
    void Update()
    {
        transform.position += direction * bulletSpeed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }


}
