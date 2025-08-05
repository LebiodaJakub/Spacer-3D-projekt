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
        doorAnimator.Play("OpenDoorAnimation");
        isDoorOpened = true;
        interactable.localizedMessage = openLocale;
    }

    void CloseDoor()
    {
        doorAnimator.Play("CloseDoorAnimation");
        isDoorOpened = false;
        interactable.localizedMessage = closeLocale;
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
