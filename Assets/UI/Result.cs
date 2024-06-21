using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    public int resultScore;
    public Text ResultText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        resultScore = PlayerPrefs.GetInt("SCORE");
        ResultText.text ="スコア　" + resultScore.ToString();
    }
}
