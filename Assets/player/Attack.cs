using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{ 

    public GameObject n_BulletObj;
    public GameObject s_BulletObj;

    public float n_cooldown = 0.5f;
    public float s_cooldown = 0.5f;
    private float n_time;
    private float s_time;
    private bool damage;
    private float damage_time;
    public float damage_cooldown;
    public float charge;
    public float charge_time;

    public AudioClip sound1;
    AudioSource audioSource;
    public AudioClip sound2;
    //AudioSource audioSource2;
    Vector3 bulletPoint;
   

    // Start is called before the first frame update
    void Start()
    {
        bulletPoint = transform.Find("BulletPoint").localPosition;
        damage = false;

        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    ///攻撃時の処理
        if (damage == false)
        {
            //左Shiftが押されている
            if (Input.GetKey(KeyCode.LeftShift))
            {
                //クールダウン終了後
                if (s_time >= s_cooldown)
                {
                    charge_time += Time.deltaTime;

                    if (charge_time > charge)
                    {
                        // ボタンを押したとき
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            // 弾の生成
                            Instantiate(s_BulletObj, transform.position + bulletPoint, Quaternion.identity);
                            audioSource.PlayOneShot(sound2);

                            //クールダウンリセット
                            s_time = 0;
                            charge_time = 0;
                        }
                    }
                }
            }
            //左Shiftが押されていない
            else
            {
                //クールダウン終了後
                if (n_time >= n_cooldown)
                {
                    // ボタンを押したとき
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        // 弾の生成
                        Instantiate(n_BulletObj, transform.position + bulletPoint, Quaternion.identity);
                        audioSource.PlayOneShot(sound1);

                        //クールダウンリセット
                        n_time = 0;
                        charge_time = 0;
                    }
                }
            }
            //n_timeを時間と同期
            n_time += Time.deltaTime;
            //Debug.Log(n_time);

            //s_timeを時間と同期
            s_time += Time.deltaTime;
            //Debug.Log(n_time);

            //色変更
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
        //攻撃不可能な時に攻撃した場合
        else if (damage == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("ダメージを受けて攻撃できない！");
            }
        }
    
    ///ダメージを食らった時の処理
        if (damage == true)
        {
            //ダメージ用カウントを開始
            damage_time += Time.deltaTime;
            //色変更
            gameObject.GetComponent<Renderer>().material.color = Color.red;

            charge_time = 0;
        }
        if (damage_time >= damage_cooldown)
        {
            damage_time = 0;
            damage = false;
        }
        
        //チャージ後の色変更
        if (charge_time > charge)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.cyan;
        }

    }

    void OnTriggerEnter2D(Collider2D Collider)
    {
        if (damage == false)
        {
            //プレイヤーに敵がぶつかった時
            Debug.Log("ダメージを食らった！");
            damage = true;
        }
    }
}
