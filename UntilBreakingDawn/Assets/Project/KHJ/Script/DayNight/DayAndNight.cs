using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DayAndNight : MonoBehaviour
{
    [SerializeField] private float ChangeDayCount = 1.0f;   // �� �� �ٲٱ� ���� �ð��� 
    [SerializeField] private float dayChange = 10.0f;       // �� �� �ٲٱ� �ִ� �ð���
    [SerializeField] private float RotateDay = 0.1f;        // ���� 100�� = ���� 1��

    private SceneManager Scene;             // �� �ٲٱ�

    private bool isNight = false;           // �� �� �ٲٱ��

    // Update is called once per frame
    void Update()
    {
        ChangeDayCount += Time.deltaTime;

        if (ChangeDayCount >= dayChange)
        {
            transform.Rotate(Vector3.right, RotateDay * Time.deltaTime);

            if (!isNight)
            {
                isNight = true;
                ChangeDayCount = 0;
            }
            else
            {
                isNight = false;
                ChangeDayCount = 0;
            }
        }

    }
}
