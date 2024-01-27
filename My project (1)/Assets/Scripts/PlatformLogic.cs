using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformLogic : MonoBehaviour
{
    public BoxCollider collider;
    public BoxCollider parentCollider;
    // Start is called before the first frame update
    void Start()
    {
        parentCollider.enabled = false;        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Entering");
        if(col.gameObject.tag == "Player")
        {
            Vector3 dir = transform.position - col.transform.position;
            dir = dir.normalized;
            float side = Mathf.Atan2(dir.y, dir.x);
     
            Debug.Log(dir);
            Debug.Log(side);
     
            if(side > 0 && side < Mathf.PI)
                parentCollider.enabled = false;
            else
            {
                parentCollider.enabled = true;
            }
        }

    }
    void OnTriggerExit(Collider col)
    {
        Debug.Log("Exiting 1");
        if(col.gameObject.CompareTag("Player"))
        {
            parentCollider.enabled = true;
        }
    }
}
