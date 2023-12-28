using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;

    private string swimming = "Swimming";
    private string perfect = "Perfect";
    private string bad = "Bad";

    // Ű�� ������ �� ������ �ִϸ��̼�
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
