using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public float MoveSpeed = 20.0f;         // 移動値
    public float DestroyTimer = 15.0f;      // 弾が消えるまでの時間

    private float time;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 位置の更新
        transform.Translate(MoveSpeed * Time.deltaTime, 0, 0);
        // 弾の削除
        Destroy(gameObject, DestroyTimer);

        time += Time.deltaTime;
        //Debug.Log(time);
    }

    //当たった瞬間の処理
    void OnTriggerEnter2D(Collider2D Collider)
    {
        //Debug.Log("hit!");
        //当たっら本体を消す
        Destroy(gameObject);
    }
}
