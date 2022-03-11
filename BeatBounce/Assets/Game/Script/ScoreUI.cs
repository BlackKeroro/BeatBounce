using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public static int Score;
    

    public Text scoretxt;


    // Start is called before the first frame update
    void Awake()
    {
        Score = 0;  
    }

    // Update is called once per frame
    void Update()
    {
        scoretxt.text = Score.ToString();
    }
}
