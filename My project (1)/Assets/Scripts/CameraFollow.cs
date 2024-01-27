using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public Vector2 limits;
    public Vector2 vLimits;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Horizontal follow
        if(player.transform.position.x > limits.x && player.transform.position.x < limits.y)
        {
            Vector3 oldTransform = transform.position;
            transform.position = new Vector3(player.transform.position.x, oldTransform.y, oldTransform.z); 
        }
        //Vertical follow
        if(player.transform.position.y > vLimits.x && player.transform.position.y < vLimits.y)
        {
            Vector3 oldTransform = transform.position;
            transform.position = new Vector3(oldTransform.x, player.transform.position.y, oldTransform.z); 
        }

    }
}
