using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //カウントダウン
    public float countdown = 100.0f;

    //時間を表示するText型の変数
    public Text timeText;
    public Text FinishText;

    //終了確認
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
        //時間をカウントダウンする
        countdown -= Time.deltaTime;
        if (finish == false)
        {
            //時間を表示する
            if (countdown > 0)
            {
                timeText.text = "残り" + countdown.ToString("f1") + "秒";
            }
            //countdownが0以下になったとき
            if (countdown <= 0)
            {
                timeText.text = "";
                FinishText.text = "Finish!";
            }
        }

        ///以下他スクリプトの同期

        PlayChange playChange = GetComponent<PlayChange>();
        playChange.countdown = countdown;

        if (finish == false)
        {
            //playスクリプトのあだ名をPlayに
            Play play;
            GameObject obj = GameObject.Find("Player"); //Playerっていうオブジェクトを探す
            play = obj.GetComponent<Play>(); //付いているスクリプトを取得
                                             //playスクリプトの変数countdownを統一
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
        //        Debug.Log("セーブしたよん");
        //    }
        //}
    }
}