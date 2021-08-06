using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    [SerializeField] GameObject stick = default;    // �����E�ړ�������I�u�W�F�N�g
    [SerializeField] GameObject player = default;

    private float totalTime = 0f;
    private float timing = 0f;
    private float time170 = 0.70588235f;
    private bool isStick = false;

    private void Update()
    {
        totalTime += Time.deltaTime * 1000f;        // �g�[�^���o�ߎ���(ms)
        timing = totalTime % (time170 * 1000f);     // 1�񖈂̌o�ߎ���(ms)

        if (timing >= time170 * 1000f - 565f && timing < time170 * 1000f - 535f) {  // 140f�`170f �̌덷�H
            if (!isStick) {
                Instantiate(stick, transform);
                isStick = true;
            }
        } else if (isStick) {
            isStick = false;
        }
    }

    
}
