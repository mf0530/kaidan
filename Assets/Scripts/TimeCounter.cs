using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class TimeCounter : MonoBehaviour
{
   
    // 変数
    public int min = 3;
    private float sec;
    private float totalTime;

    //時間表示
    public Text timeText;
 
    
    void Start()
    {
        // 総時間計算
        totalTime = min*60+sec;
    }
    

    void Update()
    {
        // カウントダウン
        totalTime = min*60+sec; 
        totalTime -= Time.deltaTime;
 
        // 分秒の更新
        min = (int)totalTime / 60;
        sec = totalTime - min*60;

        // 時間表示
        timeText.text = min.ToString("00") + ":" + ((int)sec).ToString("00");
 
        // カウントダウンが0以下になったとき
        if( totalTime <= 0 )
        {
            // ゲームオーバーの処理
        }
    }
}