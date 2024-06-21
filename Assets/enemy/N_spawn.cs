using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_spawn : MonoBehaviour
{
    [SerializeField] private float cooldown = 3.0f;
    int rnd;
    private float time;
    public GameObject n_EnemyObj;

    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;

        if (time > cooldown)
        {
            rnd = Random.Range(1, 4); //1~3‚Ì’l‚ðƒ‰ƒ“ƒ_ƒ€‚Å
        }

        
        if (rnd == 1)
        {
            Instantiate(n_EnemyObj,new Vector3(15,3,0), Quaternion.identity);
            time = 0;
            rnd = 0;
        }
        else if (rnd == 2)
        {
            Instantiate(n_EnemyObj, new Vector3(15, 0, 0), Quaternion.identity);
            time = 0;
            rnd = 0;
        }
        else if (rnd == 3)
        {
            Instantiate(n_EnemyObj, new Vector3(15, -3, 0), Quaternion.identity);
            time = 0;
            rnd = 0;
        }
    }
}
