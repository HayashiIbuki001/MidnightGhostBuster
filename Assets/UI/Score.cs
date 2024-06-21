using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public bool finish;
    public bool resultSave;
    public Text Score_Text;
    public int ScoreManager;
    // Start is called before the first frame update
    void Start()
    {
        ScoreManager = 0;
        finish = false;
        resultSave = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (finish == false)
        {
            Score_Text.text = "得点：" + ScoreManager.ToString("f0");
        }

        if (resultSave == false)
        {

            if (finish == true)
            {
                //終了時にSCOREという名前でScoreManagerの値を保存
                PlayerPrefs.SetInt("SCORE", ScoreManager);
                PlayerPrefs.Save();

                resultSave = true;
                Debug.Log("セーブしたよん");

                Score_Text.text = "";
            }
        }
    }
}
