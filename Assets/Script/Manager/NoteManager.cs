using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public float bpm;
    private double currentTime; // 오차를 줄이기 위해서 double로 선언

    [SerializeField] Transform noteCreate;
    //[SerializeField] GameObject note;

    private TimingManager timingManager;

    private void Start()
    {
        timingManager = GetComponent<TimingManager>();
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= 60 / bpm) // 1beat 당 시간
        {
            GameObject touchNote = ObjectPool.Instance.noteQueue.Dequeue();
            touchNote.transform.position = noteCreate.position;
            touchNote.SetActive(true);
            //GameObject touchNote = Instantiate(note, noteCreate.position, Quaternion.identity); // 노트 생성
            //touchNote.transform.SetParent(this.transform); // 노트가 부모인 UI 캔버스 내에서 생성되도록 한다.

            timingManager.noteList.Add(touchNote); // 노트 판정을 위해 리스트에 추가
            currentTime -= 60 / bpm; // 부동소수점 표현 방식으로 오차가 발생하기 때문에 0으로 초기화하지 않는다.
        }
    }

    private void OnTriggerEnter2D(Collider2D other) // 오브젝트 간 충돌 감지
    {
        if (other.tag == "Note")
        {
            timingManager.noteList.Remove(other.gameObject);

            ObjectPool.Instance.noteQueue.Enqueue(other.gameObject);
            other.gameObject.SetActive(false);
            //Destroy(other.gameObject);
        }
    }
}
