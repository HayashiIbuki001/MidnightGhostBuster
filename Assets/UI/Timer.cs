using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //�J�E���g�_�E��
    public float countdown = 100.0f;

    //���Ԃ�\������Text�^�̕ϐ�
    public Text timeText;
    public Text FinishText;

    //�I���m�F
    public bool finish;
    public bool resultSave;
    // Update is called once per frame

    void Start()
    {
        finish = false;
        resultSave = false;
    }

    void Update()
    {
        //���Ԃ��J�E���g�_�E������
        countdown -= Time.deltaTime;
        if (finish == false)
        {
            //���Ԃ�\������
            if (countdown > 0)
            {
                timeText.text = "�c��" + countdown.ToString("f1") + "�b";
            }
            //countdown��0�ȉ��ɂȂ����Ƃ�
            if (countdown <= 0)
            {
                timeText.text = "";
                FinishText.text = "Finish!";
            }
        }

        ///�ȉ����X�N���v�g�̓���

        PlayChange playChange = GetComponent<PlayChange>();
        playChange.countdown = countdown;

        if (finish == false)
        {
            //play�X�N���v�g�̂�������Play��
            Play play;
            GameObject obj = GameObject.Find("Player"); //Player���Ă����I�u�W�F�N�g��T��
            play = obj.GetComponent<Play>(); //�t���Ă���X�N���v�g���擾
                                             //play�X�N���v�g�̕ϐ�countdown�𓝈�
            play.countdown = countdown;
        }

        //if (countdown <= 0 )
        //{
        //    if (resultSave == false)
        //    {
        //        Score score;
        //        GameObject obj = GameObject.Find("Score");
        //        score = obj.GetComponent<Score>();
        //        score.finish = true;
        //        Debug.Log("�Z�[�u�������");
        //    }
        //}
    }
}