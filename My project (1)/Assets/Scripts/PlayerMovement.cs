using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 50.0f;
    public float jumpSpeed = 100.0f;
    public bool enableJump = false;
    public bool grounded = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //x axis movement
        float xAxis = Input.GetAxis("Horizontal");
        if(xAxis != 0.0f)
        {
            Vector3 oldV = rb.velocity;
            oldV.x = 0.0f;
            Vector3 movement = new Vector3(xAxis, 0, 0) * speed + oldV;
            rb.velocity = movement;
        }
        //Jumps
        if(Input.GetKeyDown("w") && grounded)
        {
            Jump();
            Debug.Log("First Jump");
            Debug.Log(rb.velocity);
        }
        //Double Jump
        else if(Input.GetKeyDown("w") && !grounded && enableJump)
        {
            Jump();
            enableJump = false;
            Debug.Log("Second Jump");
            Debug.Log(rb.velocity);
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
}
