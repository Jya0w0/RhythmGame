using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    private float noteSpeed = 500f;

    private Image noteImage;

    private void OnEnable()
    {
        if (noteImage == null)
        {
            noteImage = GetComponent<Image>();
        }

        noteImage.enabled = true; // ������Ʈ Ǯ�� ��Ʈ�� ��ȯ �޾��� �� �̹����� ���̰� �ϱ� ���ؼ�
    }

    // ��Ʈ�� ���ٸ� ������ ������� ���� �� �����Ƿ� �̹����� ������� �Ѵ�
    public void HideImage()
    {
        noteImage.enabled = false;
    }

    private void Update()
    {
        transform.localPosition += Vector3.left * noteSpeed * Time.deltaTime; // local�� �ؾ� Canvas ���� ��ǥ�� �����ȴ�.
    }
}
