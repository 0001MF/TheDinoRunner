using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score instance;
    int score;
    public TMP_Text textObj;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void updateScore(int CoinValue)
    {
        score += CoinValue;
        textObj.text = "Score : " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}