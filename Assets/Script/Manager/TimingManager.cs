using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public List<GameObject> noteList = new List<GameObject>(); // ������ ��Ʈ��

    [SerializeField] private Transform noteCenter; // ��Ʈ �߽� ��ġ
    [SerializeField] private RectTransform[] noteRect; // ��Ʈ ����
    private Vector2[] noteTiming; // ��������(�ּ�, �ִ�)

    private PlayerAnimation animationManager;
    private Score score;

    private void Start()
    {
        animationManager = GetComponent<PlayerAnimation>();
        score = gameObject.GetComponent<Score>();

        // ���������� ����(Perfect, Great, Good, Bad)
        noteTiming = new Vector2[noteRect.Length];
        for (int i = 0; i < noteTiming.Length; i++)
        {
            // ��Ʈ ���� ���� - �ּ� : �߽� - (��Ʈ �ʺ�/2), �ִ� : �߽� + (��Ʈ �ʺ�/2)
            noteTiming[i].Set(noteCenter.localPosition.x - noteRect[i].rect.width / 2, noteCenter.localPosition.x + noteRect[i].rect.width / 2);
        }
    }

    public void CheckNoteTiming()
    {
        for (int i = 0;i < noteList.Count;i++)
        {
            // ��Ʈ ��ġ
            float notePositionX = noteList[i].transform.localPosition.x;

            // �������� Ȯ��
            for (int j = 0; j < noteTiming.Length; j++)
            {
                if (noteTiming[j].x <= notePositionX && notePositionX <= noteTiming[j].y) // �ּ����� <= ��Ʈ x�� <= �ִ�����
                {
                    // Ű ������ ��Ʈ �����
                    noteList[i].GetComponent<Note>().HideImage();
                    noteList.RemoveAt(i);

                    // �÷��̾� �ִϸ��̼�
                    if (j == 0)
                    {
                        Debug.Log("Perfect");
                        animationManager.PerfectEffect();
                    }
                    else if (j == 3)
                    {
                        Debug.Log("Bad");
                        animationManager.BadEffect();
                    }
                    else
                    {
                        animationManager.SwimmingEffect();
                    }

                    // ���� ����
                    //score.PlusScore(j);
                    return;
                }
            }
        }
        Debug.Log("Miss");
    }
}
