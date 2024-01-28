using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public List<GameObject> portals;
    public float spawnTime = 60.0f;
    public float timer = 0.0f;
    public int count;
    public int it = 0;
    public int waves = 6;
    public float waveLength;
    // Start is called before the first frame update
    void Start()
    {
        //portals = new List<GameObject>(GameObject.FindGameObjectsWithTag("Portal"));
        foreach (GameObject portal in portals)
        {
            portal.SetActive(false);
        }
        count = portals.Count;

        waveLength = spawnTime / waves;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > it * waveLength)
        {
            int randomInt = Random.Range(0, count - 1);
            GameObject portal = portals[randomInt];
            portal.SetActive(true);
            portal.GetComponent<PortalLogic>().SetEnemyCount(5 + it);
            portals.Remove(portals[randomInt]);
            it++;
        }
    }
}
