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

    public GameObject parryBoxAnim;

    public float customGravity;

    private float jumpTimer;
    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // gravity
        if(!grounded)
        { 
            if(rb.velocity.y < 4)
            { 
                Vector3 gravity = Vector3.up * customGravity * 1.8f;
                rb.AddForce(gravity, ForceMode.Acceleration);
            }
            else{

                Vector3 gravity = Vector3.up * customGravity;
                rb.AddForce(gravity, ForceMode.Acceleration);
                
            }
        }

        Debug.Log(rb.velocity.y);

        //x axis movement
        float xAxis = Input.GetAxis("Horizontal");
        if(xAxis != 0.0f)
        {
            Vector3 oldV = rb.velocity;
            oldV.x = 0.0f;
            Vector3 movement = new Vector3(xAxis, 0, 0) * speed + oldV;
            rb.velocity = movement;
        }
        //Face the direction you are moving
        if(xAxis > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));
            parryBoxAnim.transform.localRotation = Quaternion.Euler(new Vector3(0f, -90f, 0f));
        }
        else if(xAxis < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f,270f, 0f));
            parryBoxAnim.transform.localRotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));
        }
        //Jumps
        if(Input.GetKeyDown("w") && grounded)
        {
 
            rb.useGravity = false;
            Jump();
        }
        //Double Jump
        else if(Input.GetKeyDown("w") && !grounded && enableJump)
        {
            Jump();
            enableJump = false;
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
            rb.useGravity = true;
        }
    }
}
