using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public float area = 10f;
    public float spawn_offset = 0.1f;
    //-----------------------------

    public Transform target; //where we want to shoot

    public GameObject bullet; //Your set-up prefab
    public float fireRate = 1500f; //Fire every 3 seconds
    public float shootingPower = 5f; //force of projection
    private Rigidbody rb;
 

    //TIME
    public float shootingTime = 3f; //local to store last time we shot so we can make sure its done every 3s
    public float timeSinceLastShot = 0f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        // raycast
        // Cast a ray horizontally from the enemy
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, Vector3.left, out hit, area) || Physics.Raycast(transform.position, Vector3.right, out hit, area) )
        {
            // If the ray hits the player, shoot
            if (hit.transform.tag == "Player")
            {
                Shoot();
            }
        }
               
        timeSinceLastShot += Time.deltaTime;
    }

    public void Shoot()
    { 
        if (timeSinceLastShot > shootingTime)
        { 
            Debug.Log(timeSinceLastShot); 
            timeSinceLastShot = 0; //set the local var. to current time of shooting
            Vector3 myPos = new Vector3(transform.position.x, transform.position.y, 0); //our curr position is where our muzzle points
            Vector3 targetPos = new Vector3(target.position.x, target.position.y, 0); //our curr position is where our muzzle points

            Vector3 direction = Vector3.Normalize(targetPos - myPos); //get the direction to the target
            GameObject projectile = Instantiate(bullet, myPos + direction * spawn_offset, Quaternion.identity); //create our bullet
            projectile.GetComponent<Rigidbody>().velocity = direction * shootingPower; //shoot the bullet
        }
    }

}

