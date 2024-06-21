using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Bullet : MonoBehaviour
{
    public float MoveSpeed = 20.0f;         // ˆÚ“®’l
    public float DestroyTimer = 15.0f;      // ’e‚ªÁ‚¦‚é‚Ü‚Å‚ÌŠÔ

    private float time;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // ˆÊ’u‚ÌXV
        transform.Translate(MoveSpeed * Time.deltaTime, 0, 0);
        // ’e‚Ìíœ
        Destroy(gameObject, DestroyTimer);

        time += Time.deltaTime;
        //Debug.Log(time);
    }

    //“–‚½‚Á‚½uŠÔ‚Ìˆ—
    void OnTriggerEnter2D(Collider2D Collider)
    {
        //Debug.Log("hit!");
    }
}
