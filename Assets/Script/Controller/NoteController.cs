using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    private TimingManager timingManager;
    private PlayerAnimation playerAnimation;

    private void Start()
    {
        timingManager = GetComponent<TimingManager>();
    }

    private void Update()
    {
        // 판정 체크
        if (Input.GetKeyDown(KeyCode.Space))
        {
            timingManager.CheckNoteTiming();
        }
    }
}
