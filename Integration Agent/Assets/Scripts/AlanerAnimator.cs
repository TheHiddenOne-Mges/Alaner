// Alaner Animator Stub - Triggers Unity Animator transitions

using UnityEngine;

public class AlanerAnimator : MonoBehaviour
{
    public Animator unityAnimator;

    public void TriggerReact()
    {
        if (unityAnimator != null)
        {
            unityAnimator.SetTrigger("React");
        }
    }
}