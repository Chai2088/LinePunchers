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
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), parentCollider.gameObject.layer, true);       
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Enemy"), parentCollider.gameObject.layer, true);     
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player" || col.gameObject.tag == "Enemy")
        {
            Vector3 dir = transform.position - col.transform.position;
            dir = dir.normalized;
            float side = Mathf.Atan2(dir.y, dir.x);
     
     
            if(side > 0 && side < Mathf.PI)
            {
                Physics.IgnoreLayerCollision(col.gameObject.layer, parentCollider.gameObject.layer, true);
            }
            else
            {
                Physics.IgnoreLayerCollision(col.gameObject.layer, parentCollider.gameObject.layer, false);
            }
        }

    }
    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.CompareTag("Player") || col.gameObject.tag == "Enemy")
        {
            //Make sure your position is higher than the platforms
            if(col.transform.position.y > parentCollider.transform.position.y)
            {
                Physics.IgnoreLayerCollision(col.gameObject.layer, parentCollider.gameObject.layer, false);
            }
        }
    }
}
