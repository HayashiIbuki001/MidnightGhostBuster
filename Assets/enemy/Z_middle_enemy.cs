using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Z_middle_enemy : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    [SerializeField] private float speed = 10f;
    [SerializeField] private int Point = 500;

    AudioSource audioSource;
    public AudioClip sound1;
    public GameObject effectPrefab;

    private float x = 20;
    public float y = 0;
    public float theta = 0;

    // Start is called before the first frame update
    void Start()
    {
        //rigidbody�擾
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.AddForce(Vector3.left * speed * 10, ForceMode2D.Force);

        //Component���擾
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        x -= 0.01f;
        y = Mathf.Sin(theta) * 3;
        

        transform.position = new Vector3(x, y);

        theta += (2f * Mathf.PI / 360) / 5;

        Destroy(gameObject, 8);

    }

    //�e�ɓ���������
    void OnTriggerEnter2D(Collider2D Collider)
    {
        if (Collider.gameObject.tag == "attack")
        {
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
