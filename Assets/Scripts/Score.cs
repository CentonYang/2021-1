using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text ScoreTxt;

    void Update()
    {
        ScoreTxt.text = "靈魂：" + GameManager.Score.ToString() + " / " + GameManager.MaxScore;
    }
}
