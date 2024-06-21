using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class H_enemy : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private int Point = 300;
    private new Rigidbody2D rigidbody;

    AudioSource audioSource;
    public AudioClip sound1;
    public GameObject effectPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //rigidbody�擾
        rigidbody = GetComponent<Rigidbody2D>();
        //�ړ�
        rigidbody.AddForce(Vector3.left * speed * 20, ForceMode2D.Force);

        //Component���擾
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 5);
    }

    //�e�ɓ���������
    void OnTriggerEnter2D(Collider2D Collider)
    {
        if (Collider.gameObject.tag == "attack")
        {
            //Debug.Log("�|������");
            //�G������
            Destroy(gameObject);

            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            AudioSource.PlayClipAtPoint(sound1, transform.position);


            //�_����ScoreManager�ɒǉ�
            Score score;
            GameObject obj = GameObject.Find("Score");
            score = obj.GetComponent<Score>();
            score.ScoreManager += Point;
        }
    }
}
