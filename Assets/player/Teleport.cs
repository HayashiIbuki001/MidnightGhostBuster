using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Teleport : MonoBehaviour
{
    //�e���|�[�g����Player�̒l
    int PlayerTeleport = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        //Player�̏ꏊ�������̎�
        if(PlayerTeleport == 0)
        {
            //����TP +1
            if (Input.GetKeyDown(KeyCode.W))
            {
                //Debug.Log("1");
                transform.position = new Vector3(-7, 3, 0);
                PlayerTeleport = 1;
            }
            //�����TP -1
            else if (Input.GetKeyDown(KeyCode.S))
            {
                //Debug.Log("-1");
                transform.position = new Vector3(-7, -3, 0);
                PlayerTeleport = -1;
            }
        }
        //Player�̏ꏊ�����̎�
        else if(PlayerTeleport == 1)
        {
            //�����ɂ̂�TP 0
            if (Input.GetKey(KeyCode.S))
            {
                //Debug.Log("0");
                transform.position = new Vector3(-7, 0, 0);
                PlayerTeleport = 0;
            }
        }
        //Player�̏ꏊ������̎�
        else if (PlayerTeleport == -1)
        {
            //�����ɂ̂�TP 0
            if (Input.GetKey(KeyCode.W))
            {
                //Debug.Log("0");
                transform.position = new Vector3(-7, 0, 0);
                PlayerTeleport = 0;
            }
        }
    }
}
