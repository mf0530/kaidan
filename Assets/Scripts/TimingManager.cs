using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    [SerializeField] GameObject stick = default;    // 生成・移動させるオブジェクト

    private float totalTime = 0f;
    private float timing = 0f;
    private bool isStick = false;

    private void Update()
    {
        totalTime += Time.deltaTime * 1000f;            // トータル経過時間(ms)
        timing = totalTime % (120f / 170f * 1000f);     // 1回毎の経過時間(ms)


        if (timing >= 120f / 170f * 1000f - 15f && timing <= 120f / 170f * 1000f - 5f) {       // タイミングを測る　固定値でOKっぽい
            if (!isStick) {
                Instantiate(stick, transform);
                isStick = true;
            }
        } else if (isStick) {
            isStick = false;
        }
    }
}
