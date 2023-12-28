using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectInfo // ��Ʈ ����
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
        // ������Ʈ Ǯ�� �ڽ� ������Ʈ�� ��Ʈ�� �̸� ����� ��Ȱ��ȭ
        for (int i = 0; i < objectInfo.count; i++)
        {
            GameObject noteClone = Instantiate(objectInfo.notePrefab, transform.position, Quaternion.identity);
            noteClone.SetActive(false);

            // �θ� ������Ʈ�� �����Ѵٸ� �� ������Ʈ�� �θ��, �ƴ϶�� �ڱ� �ڽ��� �θ�� ��´�.
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
