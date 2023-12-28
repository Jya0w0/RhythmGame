using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectInfo // 노트 종류
{
    public GameObject notePrefab;
    public int count;
    public Transform poolParent;
}

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    [SerializeField] private ObjectInfo[] objectInfo;

    public Queue<GameObject> noteQueue = new Queue<GameObject>();

    private void Awake()
    {
        Instance = this;
        noteQueue = InsertQueue(objectInfo[0]);
    }

    private Queue<GameObject> InsertQueue(ObjectInfo objectInfo)
    {
        Queue<GameObject> queue = new Queue<GameObject>();
        // 오브젝트 풀의 자식 오브젝트로 노트를 미리 만들고 비활성화
        for (int i = 0; i < objectInfo.count; i++)
        {
            GameObject noteClone = Instantiate(objectInfo.notePrefab, transform.position, Quaternion.identity);
            noteClone.SetActive(false);

            // 부모 오브젝트가 존재한다면 그 오브젝트를 부모로, 아니라면 자기 자신을 부모로 삼는다.
            if (objectInfo.poolParent != null)
            {
                noteClone.transform.SetParent(objectInfo.poolParent);
            }
            else
            {
                noteClone.transform.SetParent(this.transform);
            }

            queue.Enqueue(noteClone);
        }

        return queue;
    }
}
