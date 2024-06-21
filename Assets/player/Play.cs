using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    public float countdown;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown < 0)
        {
            //Destroy(gameObject);
            GameObject kill = GameObject.FindWithTag("Enemy");
            Destroy(kill);

            Timer timer;
            GameObject obj = GameObject.Find("Timer");
            timer = obj.GetComponent<Timer>();
            timer.finish = true;
        }

        if (countdown < 0)
        {
            Score score;
            GameObject obj = GameObject.Find("Score");
            score = obj.GetComponent<Score>();
            score.finish = true;
         // Debug.Log("ÉZÅ[ÉuÇµÇΩÇÊÇÒ");
        }
    }
}
