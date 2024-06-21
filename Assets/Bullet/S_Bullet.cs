using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Bullet : MonoBehaviour
{
    public float MoveSpeed = 20.0f;         // �ړ��l
    public float DestroyTimer = 15.0f;      // �e��������܂ł̎���

    private float time;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // �ʒu�̍X�V
        transform.Translate(MoveSpeed * Time.deltaTime, 0, 0);
        // �e�̍폜
        Destroy(gameObject, DestroyTimer);

        time += Time.deltaTime;
        //Debug.Log(time);
    }

    //���������u�Ԃ̏���
    void OnTriggerEnter2D(Collider2D Collider)
    {
        //Debug.Log("hit!");
    }
}
