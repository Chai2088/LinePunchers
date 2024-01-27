using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalLogic : MonoBehaviour
{
    public GameObject enemy;
    public Animator anim;
    public int enemyCount = 5;
    public float timer = 0.0f;
    public float spawnTime = 2.0f;
    public int counter = 0;
    public float dt;
    bool endSpawn = false;
    public float nTime;
    // Start is called before the first frame update
    void Start()
    {
        if(enemyCount > 0)
            dt = spawnTime / enemyCount;
        
        anim.Play("EnterContainer");
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        nTime = stateInfo.normalizedTime;
        if(stateInfo.normalizedTime < 0.9f)
            return;
        if(endSpawn)
            return;
        timer += Time.deltaTime;
        if(timer > counter * dt)
        {
            Instantiate(enemy, transform.position + new Vector3(counter * 1.0f, 0.0f, 0.0f), Quaternion.identity);
            counter++;
        }
        if(counter == enemyCount)
            endSpawn = true;
    }
}
