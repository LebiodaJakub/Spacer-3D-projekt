using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;

[RequireComponent(typeof(Interactable))]
public class StickyNote : MonoBehaviour
{
    [SerializeField] LocalizedString localizedString;
    [SerializeField][TextArea()] string content;
    Interactable interactable;

    private void Awake()
    {
        interactable = GetComponent<Interactable>();
        interactable.OnInteraction += OpenStickyNote;
    }

    void OpenStickyNote()
    {
        if (localizedString != null)
            UIPopUpManager.Instance.OpenPopUp(localizedString);
        else
            UIPopUpManager.Instance.OpenPopUp(content);
    }

    private void OnDestroy()
    {
        interactable.OnInteraction -= OpenStickyNote;
    }
}
