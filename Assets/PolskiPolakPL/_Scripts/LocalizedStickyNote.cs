using UnityEngine;
using UnityEngine.Localization;

[RequireComponent(typeof(Interactable))]
public class LocalizedStickyNote : MonoBehaviour
{
    [SerializeField] LocalizedString localizedString;
    Interactable interactable;

    private void Awake()
    {
        interactable = GetComponent<Interactable>();
        interactable.OnInteraction += OpenStickyNote;
    }

    void OpenStickyNote()
    {
        UIPopUpManager.Instance.OpenPopUp(localizedString);
    }

    private void OnDestroy()
    {
        interactable.OnInteraction -= OpenStickyNote;
    }
}
