using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatBarUILogic : MonoBehaviour
{
    public GameObject Cat;
    public Image bar;
    public float catEndurance;
    public float maxCatEndurance;
    public Vector2 Range;
    public float posX;
    // Start is called before the first frame update
    void Start()
    {
        catEndurance = Cat.GetComponent<CatHealthLogic>().health;
        maxCatEndurance = catEndurance;
    }

    // Update is called once per frame
    void Update()
    {
        if(catEndurance > 0.0f)
        {
            catEndurance = Cat.GetComponent<CatHealthLogic>().health;
            posX = Range.x + (Range.y - Range.x) * (1.0f - (catEndurance / maxCatEndurance)) ;

            Vector3 oldPos = bar.transform.localPosition;
            bar.transform.localPosition = new Vector3(posX, oldPos.y, 0.0f);
        }
    }
}
