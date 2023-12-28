using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;

    private string swimming = "Swimming";
    private string perfect = "Perfect";
    private string bad = "Bad";

    // 키를 눌렀을 때 나오는 애니메이션
    public void SwimmingEffect()
    {
        playerAnimator.SetTrigger(swimming);
    }

    public void PerfectEffect()
    {
        playerAnimator.SetTrigger(perfect);
    }

    public void BadEffect()
    {
        playerAnimator.SetTrigger(bad);
    }
}
