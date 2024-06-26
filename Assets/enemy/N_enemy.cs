using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class N_enemy : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private int Point = 100;
    private new Rigidbody2D rigidbody;

    AudioSource audioSource;
    public AudioClip sound1;
    public GameObject effectPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //rigidbody取得
        rigidbody = GetComponent<Rigidbody2D>();
        //移動
        rigidbody.AddForce(Vector3.left * speed * 10,ForceMode2D.Force);

        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 5);
    }

    //弾に当たったら
    void OnTriggerEnter2D(Collider2D Collider)
    {
        if (Collider.gameObject.tag == "attack")
        {
            //敵を消す
            Destroy(gameObject);

            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            AudioSource.PlayClipAtPoint(sound1, transform.position);

            //点数をScoreManagerに追加
            Score score;
            GameObject obj = GameObject.Find("Score");
            score = obj.GetComponent<Score>();
            score.ScoreManager += Point;
        }
    }
}
