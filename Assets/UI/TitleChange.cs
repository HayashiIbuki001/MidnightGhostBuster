using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//Unity�G���W���̃V�[���Ǘ��v���O�����𗘗p����

public class TitleChange : MonoBehaviour //SceneChange�Ƃ������O�ɂ��܂�
{
    public void change_button() //change_button�Ƃ������O�ɂ��܂�
    {
        SceneManager.LoadScene("PlayScene");//second���Ăяo���܂�
    }
}