using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsManager : MonoBehaviour
{

    float StageSize = 0.8f;
    int StageIndex;

    public GameObject StairStep; //ステージのプレハブ
    public GameObject StairStepLast;
    // ノーツ数
    public int steps = 340 - 16;
    private int line;
    
    // ジャンプカウント
    private int count=0;
    
    // Start is called before the first frame update
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        line = steps / 8;
        
    if (Input.GetKeyDown(KeyCode.Space))
            {
                

                while(count<line){
                    count++;
                    Instantiate(StairStep, new Vector3(-3.35f,7.01f + 9.6f * count, 0), Quaternion.identity);    
                }
                if (count==line){
                    count++;
                    Instantiate(StairStepLast, new Vector3(-3.35f, 7.01f + 9.6f * count, 0), Quaternion.identity);
                }
            }
    }
}