using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultChange : MonoBehaviour
{
    // Start is called before the first frame update
    public void change_button()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
