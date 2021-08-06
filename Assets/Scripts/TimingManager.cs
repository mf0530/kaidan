using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    [SerializeField] GameObject stick = default;    // �����E�ړ�������I�u�W�F�N�g

    private float totalTime = 0f;
    private float timing = 0f;
    private bool isStick = false;

    private void Update()
    {
        totalTime += Time.deltaTime * 1000f;            // �g�[�^���o�ߎ���(ms)
        timing = totalTime % (120f / 170f * 1000f);     // 1�񖈂̌o�ߎ���(ms)


        if (timing >= 120f / 170f * 1000f - 15f && timing <= 120f / 170f * 1000f - 5f) {       // �^�C�~���O�𑪂�@�Œ�l��OK���ۂ�
            if (!isStick) {
                Instantiate(stick, transform);
                isStick = true;
            }
        } else if (isStick) {
            isStick = false;
        }
    }
}
