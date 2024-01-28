using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementBehaviour : MonoBehaviour
{
    public float EnemySpeed = 1.0f;
    public int health = 3;

    public float area = 10f;
    public float jumpSpeed = 100.0f;
    public bool enableJump = false;
    public bool grounded = true;

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
    private ParticleSystem particles;

    //Color value that we can set in Ispector
    [SerializeField]
    private Color color1ToTurnTo = Color.white;
    [SerializeField]
    private Color color2ToTurnTo = Color.white;


    public float raycastDistance = 10.0f;
    private LayerMask obstacleLayer;

    public Animator anim;

    void Start()
    {
        currentlyDamaged = true;
        player = GameObject.FindWithTag("Player").transform;
        EnemyRb2d = GetComponent<Rigidbody>();
        obstacleLayer = 1 << LayerMask.NameToLayer("PlatformEnabled");
        particles = GetComponent<ParticleSystem>();
        particles.Stop();
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
        anim.SetBool("Walk", runForIt);
        //Flip gameObject
        Vector3 dir = player.transform.position - transform.position;

        Debug.Log(dir);
        if(dir.x > 0.0f)
        {
            Vector3 oldScale = transform.localScale;
            transform.localScale = new Vector3(oldScale.x, oldScale.y, -Mathf.Abs(oldScale.z));
        }
        else
        {
            Vector3 oldScale = transform.localScale;
            transform.localScale = new Vector3(oldScale.x, oldScale.y, Mathf.Abs(oldScale.z));
        }
        //Flip shoot direction
        if (player.transform.position.x < gameObject.transform.position.x && facingRight)
        {
            Flip();
        }

        if (player.transform.position.x > gameObject.transform.position.x && !facingRight)
        {
            Flip();
        }
        //Player is higher than the enemy
        if(player.transform.position.y - player.transform.localScale.y * 0.5f > transform.position.y)
        {
            //Check if there is platform above
            Ray ray = new Ray(transform.position, Vector3.up);

            // Check if the ray hits any colliders within the specified distance and on the specified layer
            if (Physics.Raycast(ray, raycastDistance, obstacleLayer))
            {
                // There is an object above
                Jump();
            }
        }   

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
            //ChangeColor(color2ToTurnTo);

        }

        else
        {
            //ChangeColor(color1ToTurnTo);
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

    void OnCollisionEnter(Collision collision)
    { 
        if(collision.gameObject.tag == "Floor")
        {
            grounded = true;
            enableJump = true;
        } 
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            bulletHit = true;
            TakeDamage(1);
            //ChangeColor(color1ToTurnTo);
        }
    }

    private void ChangeColor(Color colorToChange)
    {
        rend = GetComponent<Renderer>();

        rend.material.color = colorToChange;

    }

    public void TakeDamage(int damage)
    {
        anim.Play("Armature|Hurt");
        health -= damage;
        particles.Play();
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
    void Jump()
    {
        if(grounded)
        {
            Vector3 oldVelocity = EnemyRb2d.velocity;
            EnemyRb2d.velocity = new Vector3(oldVelocity.x, jumpSpeed, oldVelocity.z);
            grounded = false;
        }
    }
}

