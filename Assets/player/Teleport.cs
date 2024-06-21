using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Teleport : MonoBehaviour
{
    //テレポート時のPlayerの値
    int PlayerTeleport = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        //Playerの場所が中央の時
        if(PlayerTeleport == 0)
        {
            //上列にTP +1
            if (Input.GetKeyDown(KeyCode.W))
            {
                //Debug.Log("1");
                transform.position = new Vector3(-7, 3, 0);
                PlayerTeleport = 1;
            }
            //下列にTP -1
            else if (Input.GetKeyDown(KeyCode.S))
            {
                //Debug.Log("-1");
                transform.position = new Vector3(-7, -3, 0);
                PlayerTeleport = -1;
            }
        }
        //Playerの場所が上列の時
        else if(PlayerTeleport == 1)
        {
            //中央にのみTP 0
            if (Input.GetKey(KeyCode.S))
            {
                //Debug.Log("0");
                transform.position = new Vector3(-7, 0, 0);
                PlayerTeleport = 0;
            }
        }
        //Playerの場所が下列の時
        else if (PlayerTeleport == -1)
        {
            //中央にのみTP 0
            if (Input.GetKey(KeyCode.W))
            {
                //Debug.Log("0");
                transform.position = new Vector3(-7, 0, 0);
                PlayerTeleport = 0;
            }
        }
    }
}
