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

        noteImage.enabled = true; // 오브젝트 풀의 노트를 반환 받았을 때 이미지가 보이게 하기 위해서
    }

    // 노트가 없다면 음악이 재생되지 않을 수 있으므로 이미지만 사라지게 한다
    public void HideImage()
    {
        noteImage.enabled = false;
    }

    private void Update()
    {
        transform.localPosition += Vector3.left * noteSpeed * Time.deltaTime; // local로 해야 Canvas 내의 좌표가 지정된다.
    }
}
