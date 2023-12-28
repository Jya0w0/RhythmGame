using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshPro score;

    [SerializeField] private int defaultScore = 10000;
    private int currentScore = 0;

    [SerializeField] float[] judgeScore;

    private void Start()
    {
        currentScore = 0;
        score.text = "0";
    }

    public void PlusScore(int judgeNote)
    {
        int plusScore = defaultScore;

        // �þ�� ����
        plusScore = (int)(plusScore * judgeScore[judgeNote]);

        currentScore += plusScore;
        score.text = string.Format("{0:#,##0}", currentScore); // ���ڸ������� �޸�
    }
}
