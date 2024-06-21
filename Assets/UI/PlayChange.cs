using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayChange : MonoBehaviour
{
    public float countdown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown < -3)
        {
            SceneManager.LoadScene("ResultScene");
        }
    }
}
