using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DoorAnimation : MonoBehaviour
{
    Collider doorCollider;
    [SerializeField] Animator doorAnimator;

    private void OnValidate()
    {
        doorAnimator = GetComponent<Animator>();

        //Collider
        if (!TryGetComponent<Collider>(out doorCollider))
        {
            Debug.LogWarning("The door does not have a Collider.");
        }
    }
    public void SetAnimatorController(RuntimeAnimatorController controller)
    {
        doorAnimator.runtimeAnimatorController = controller;
    }

    public void PlayAnimation(AnimationClip animationClip)
    {
        if (!animationClip)
        {
            Debug.LogWarning("Open Animation is not attached!");
            return;
        }
        doorAnimator.Play(animationClip.name);
    }

    void EnableCollider()
    {
        doorCollider.enabled = true;
    }

    void DisableCollider()
    {
        doorCollider.enabled = false;
    }
}
