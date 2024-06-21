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

        //Component���擾
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    ///�U�����̏���
        if (damage == false)
        {
            //��Shift��������Ă���
            if (Input.GetKey(KeyCode.LeftShift))
            {
                //�N�[���_�E���I����
                if (s_time >= s_cooldown)
                {
                    charge_time += Time.deltaTime;

                    if (charge_time > charge)
                    {
                        // �{�^�����������Ƃ�
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            // �e�̐���
                            Instantiate(s_BulletObj, transform.position + bulletPoint, Quaternion.identity);
                            audioSource.PlayOneShot(sound2);

                            //�N�[���_�E�����Z�b�g
                            s_time = 0;
                            charge_time = 0;
                        }
                    }
                }
            }
            //��Shift��������Ă��Ȃ�
            else
            {
                //�N�[���_�E���I����
                if (n_time >= n_cooldown)
                {
                    // �{�^�����������Ƃ�
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        // �e�̐���
                        Instantiate(n_BulletObj, transform.position + bulletPoint, Quaternion.identity);
                        audioSource.PlayOneShot(sound1);

                        //�N�[���_�E�����Z�b�g
                        n_time = 0;
                        charge_time = 0;
                    }
                }
            }
            //n_time�����ԂƓ���
            n_time += Time.deltaTime;
            //Debug.Log(n_time);

            //s_time�����ԂƓ���
            s_time += Time.deltaTime;
            //Debug.Log(n_time);

            //�F�ύX
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
        //�U���s�\�Ȏ��ɍU�������ꍇ
        else if (damage == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("�_���[�W���󂯂čU���ł��Ȃ��I");
            }
        }
    
    ///�_���[�W��H��������̏���
        if (damage == true)
        {
            //�_���[�W�p�J�E���g���J�n
            damage_time += Time.deltaTime;
            //�F�ύX
            gameObject.GetComponent<Renderer>().material.color = Color.red;

            charge_time = 0;
        }
        if (damage_time >= damage_cooldown)
        {
            damage_time = 0;
            damage = false;
        }
        
        //�`���[�W��̐F�ύX
        if (charge_time > charge)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.cyan;
        }

    }

    void OnTriggerEnter2D(Collider2D Collider)
    {
        if (damage == false)
        {
            //�v���C���[�ɓG���Ԃ�������
            Debug.Log("�_���[�W��H������I");
            damage = true;
        }
    }
}
