using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public List<GameObject> noteList = new List<GameObject>(); // 생성된 노트들

    [SerializeField] private Transform noteCenter; // 노트 중심 위치
    [SerializeField] private RectTransform[] noteRect; // 노트 판정
    private Vector2[] noteTiming; // 판정범위(최소, 최대)

    private PlayerAnimation animationManager;
    private Score score;

    private void Start()
    {
        animationManager = GetComponent<PlayerAnimation>();
        score = gameObject.GetComponent<Score>();

        // 판정범위들 설정(Perfect, Great, Good, Bad)
        noteTiming = new Vector2[noteRect.Length];
        for (int i = 0; i < noteTiming.Length; i++)
        {
            // 노트 판정 범위 - 최소 : 중심 - (노트 너비/2), 최대 : 중심 + (노트 너비/2)
            noteTiming[i].Set(noteCenter.localPosition.x - noteRect[i].rect.width / 2, noteCenter.localPosition.x + noteRect[i].rect.width / 2);
        }
    }

    public void CheckNoteTiming()
    {
        for (int i = 0;i < noteList.Count;i++)
        {
            // 노트 위치
            float notePositionX = noteList[i].transform.localPosition.x;

            // 판정범위 확인
            for (int j = 0; j < noteTiming.Length; j++)
            {
                if (noteTiming[j].x <= notePositionX && notePositionX <= noteTiming[j].y) // 최소판정 <= 노트 x값 <= 최대판정
                {
                    // 키 누르면 노트 지우기
                    noteList[i].GetComponent<Note>().HideImage();
                    noteList.RemoveAt(i);

                    // 플레이어 애니메이션
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

                    // 점수 증가
                    //score.PlusScore(j);
                    return;
                }
            }
        }
        Debug.Log("Miss");
    }
}
