using UnityEngine;
using UnityEngine.Localization;

public class DoorScript : MonoBehaviour
{
    [Header("Door Settings")]
    [SerializeField] GameObject doorsGO;
    public bool Locked = false;
    [SerializeField] Interactable interactable;

    [Header("Animation")]
    [SerializeField] DoorAnimation doorAnimationScript;
    public RuntimeAnimatorController animatorController;
    public AnimationClip openAnimation;
    public AnimationClip closeAnimation;

    [Header("Language Localization")]
    [SerializeField] LocalizedString openLocale;
    [SerializeField] LocalizedString closeLocale;

    bool isDoorOpened = false;

#if UNITY_EDITOR

    private void OnValidate()
    {
        if (!doorsGO)
            return;
        SetDoorsComponents();
        if (animatorController)
            doorAnimationScript.SetAnimatorController(animatorController);
    }

    private void SetDoorsComponents()
    {
        //Interaction
        if(!doorsGO.TryGetComponent<Interactable>(out interactable))
        {
            interactable = doorsGO.AddComponent<Interactable>();
        }
        GetInteractionMessage();

        //Animation
        if (!doorsGO.TryGetComponent<DoorAnimation>(out doorAnimationScript))
        {
            doorAnimationScript = doorsGO.AddComponent<DoorAnimation>();
        }
    }

#endif

    private void Awake()
    {
        interactable.OnInteraction += DoInteraction;
    }

    public void DoInteraction()
    {
        if (Locked)
            return;
        if (isDoorOpened)
            CloseDoor();
        else
            OpenDoor();
    }

    void OpenDoor()
    {
        doorAnimationScript.PlayAnimation(openAnimation);
        isDoorOpened = true;
        GetInteractionMessage();
    }

    void CloseDoor()
    {
        doorAnimationScript.PlayAnimation(closeAnimation);
        isDoorOpened = false;
        GetInteractionMessage();
    }

    void GetInteractionMessage()
    {
        if (Locked)
        {
            interactable.message = "<color=#ff0000>[LOCKED]</color>";
            return;
        }
        if (isDoorOpened)
        {
            interactable.localizedMessage = closeLocale;
            interactable.message = "Close";
        }
        else
        {
            interactable.localizedMessage = openLocale;
            interactable.message = "Open";
        }
    }

    private void OnDestroy()
    {
        interactable.OnInteraction -= DoInteraction;
    }
}
