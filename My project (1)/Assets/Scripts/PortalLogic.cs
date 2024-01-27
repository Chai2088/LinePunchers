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

    public float wallTimer = 0.0f;
    private SpriteRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        if(enemyCount > 0)
            dt = spawnTime / enemyCount;
        
        anim.Play("EnterContainer");
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        nTime = stateInfo.normalizedTime;

        if(stateInfo.normalizedTime < 0.9f)
            return;
        if(stateInfo.normalizedTime > 1.0f)
            RestoreWall();
        
        if(endSpawn)
            return;
        timer += Time.deltaTime;
        if(timer > counter * dt)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            counter++;
        }
        if(counter == enemyCount)
            endSpawn = true;
    }
    void RestoreWall()
    {
        if(wallTimer < 1.5f)
        {
            wallTimer += Time.deltaTime;
            Vector4 color = rend.color;
            rend.color = new Vector4(color.x, color.y, color.z, 1.0f - (wallTimer / 1.5f));
        }
    }
}
