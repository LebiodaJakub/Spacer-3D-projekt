using UnityEngine;

[RequireComponent(typeof(Interactable))]
[RequireComponent(typeof(Animator))]
public class DoorScript : MonoBehaviour
{
    Animator doorAnimator;
    [SerializeField] bool isDoorOpened = false;

    Interactable interactable;
    Collider doorCollider;
    public bool Locked = false;

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
        interactable.message = "Close";
    }

    void CloseDoor()
    {
        doorAnimator.Play("CloseDoorAnimation");
        isDoorOpened = false;
        interactable.message = "Open";
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
