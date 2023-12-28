using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public float bpm;
    private double currentTime; // ������ ���̱� ���ؼ� double�� ����

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

        if (currentTime >= 60 / bpm) // 1beat �� �ð�
        {
            GameObject touchNote = ObjectPool.Instance.noteQueue.Dequeue();
            touchNote.transform.position = noteCreate.position;
            touchNote.SetActive(true);
            //GameObject touchNote = Instantiate(note, noteCreate.position, Quaternion.identity); // ��Ʈ ����
            //touchNote.transform.SetParent(this.transform); // ��Ʈ�� �θ��� UI ĵ���� ������ �����ǵ��� �Ѵ�.

            timingManager.noteList.Add(touchNote); // ��Ʈ ������ ���� ����Ʈ�� �߰�
            currentTime -= 60 / bpm; // �ε��Ҽ��� ǥ�� ������� ������ �߻��ϱ� ������ 0���� �ʱ�ȭ���� �ʴ´�.
        }
    }

    private void OnTriggerEnter2D(Collider2D other) // ������Ʈ �� �浹 ����
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
