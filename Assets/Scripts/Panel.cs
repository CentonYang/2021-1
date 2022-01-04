using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    private float Timing = 0;
    public Text Results;
    public Text UseTime;
    public GameObject Continue;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Results.text == "失敗了！")
        {
            GetComponent<Animator>().Play("PanelUnfold");
            Destroy(Continue);
        }
        else if (Results.text == "獲勝了！")
        {
            Camera.main.transform.GetChild(0).gameObject.SetActive(false);
            Continue.transform.GetChild(0).GetComponent<Text>().text = "逛逛地圖";
        }
        else
        {
            Timing += Time.deltaTime;
            UseTime.text = "遊戲時間：" + ((int)Timing / 60 > 0 ? ((int)Timing / 60).ToString("00") + " 分 " : "") + ((int)Timing % 60).ToString("00") + " 秒";
            if (GameManager.Score >= GameManager.MaxScore)
            {
                Results.text = "獲勝了！";
                GetComponent<Animator>().Play("PanelUnfold");
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("PanelFold"))
                GetComponent<Animator>().Play("PanelUnfold");
            else GetComponent<Animator>().Play("PanelFold");
        }
    }

    public void Unfold()
    {
        GetComponent<Animator>().Play("PanelUnfold");
    }

    public void Fold()
    {
        GetComponent<Animator>().Play("PanelFold");
    }
}
