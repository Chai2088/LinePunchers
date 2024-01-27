using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementBehaviour : MonoBehaviour
{
    public float EnemySpeed = 1.0f;
    public int health = 3;

    public float area = 10f;

    public bool facingRight = false;
    Quaternion charecterScale;

    [HideInInspector]
    public bool runForIt = true;

    private Transform player;
    private Rigidbody EnemyRb2d;


    public float damagedTime = 0.3f;
    public float timeSinceChangedColors = 0f;
    bool bulletHit = false;
    bool currentlyDamaged = false;

    //Reference to sprite renderer component
    private Renderer rend;

    //Color value that we can set in Ispector
    [SerializeField]
    private Color color1ToTurnTo = Color.white;
    [SerializeField]
    private Color color2ToTurnTo = Color.white;

    void Start()
    {
        currentlyDamaged = true;
        player = GameObject.FindWithTag("Player").transform;
        EnemyRb2d = GetComponent<Rigidbody>();
    }


    void Update()
    {

        float distanceToPlayer = (player.position - transform.position).magnitude;
        if (distanceToPlayer < area)
        {
            runForIt = true;
        }
        else
            runForIt = false;

        if (runForIt)
        {
            Vector3 direction = new Vector3(player.position.x, player.position.y, 0) - new Vector3(transform.position.x, transform.position.y, 0);
            direction = direction.normalized;
            EnemyRb2d.MovePosition(EnemyRb2d.position + direction * EnemySpeed * Time.deltaTime);

        }

        if (player.transform.position.x < gameObject.transform.position.x && facingRight)
            Flip();
        if (player.transform.position.x > gameObject.transform.position.x && !facingRight)
            Flip();

        //COLOR ---------------------------------


        //Check if I have been damaged 
        if (bulletHit)
        {
            timeSinceChangedColors += Time.deltaTime;
            if (timeSinceChangedColors > damagedTime)
            {
                timeSinceChangedColors = 0f;
                currentlyDamaged = true;
                bulletHit = false;
            }
            else
            {
                currentlyDamaged = false;
            }
        }

        if (currentlyDamaged)
        {
            ChangeColor(color2ToTurnTo);

        }

        else
        {
            ChangeColor(color1ToTurnTo);
        }


    }

    void Flip()
    {
        //here your flip funktion, as example
        facingRight = !facingRight;
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x *= -1;
        gameObject.transform.localScale = tmpScale;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

    
        if (collision.gameObject.tag == "PlayerBullet")
        {

            bulletHit = true;
            TakeDamage(1);
        }
 
    }

    private void ChangeColor(Color colorToChange)
    {
        rend = GetComponent<Renderer>();

        rend.material.color = colorToChange;

    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}

