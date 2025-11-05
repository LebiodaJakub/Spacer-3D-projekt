using UnityEngine;
using UnityEngine.Localization;

[RequireComponent(typeof(Interactable))]
[RequireComponent(typeof(Animator))]
public class DoorScript : MonoBehaviour
{
    [SerializeField] LocalizedString openLocale;
    [SerializeField] LocalizedString closeLocale;

    public bool Locked = false;

    Animator doorAnimator;
    [SerializeField] Animation openAnimation;
    [SerializeField] Animation closeAnimation;
    bool isDoorOpened = false;
    Interactable interactable;
    Collider doorCollider;

    private void Awake()
    {
        interactable = GetComponent<Interactable>();
        doorAnimator = GetComponent<Animator>();
        interactable.OnInteraction += DoInteraction;
        doorCollider = GetComponent<Collider>();
    }

    public void DoInteraction()
    {
        if (isDoorOpened)
            CloseDoor();
        else
            OpenDoor();
    }

    void OpenDoor()
    {
        if (openAnimation)
            doorAnimator.Play(openAnimation.name);
        else
            doorAnimator.Play("OpenDoorAnimation");
        isDoorOpened = true;
        interactable.localizedMessage = closeLocale;
    }

    void CloseDoor()
    {
        if (openAnimation)
            doorAnimator.Play(closeAnimation.name);
        else
            doorAnimator.Play("CloseDoorAnimation");
        isDoorOpened = false;
        interactable.localizedMessage = openLocale;
    }

    private void OnDestroy()
    {
        interactable.OnInteraction -= DoInteraction;
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
