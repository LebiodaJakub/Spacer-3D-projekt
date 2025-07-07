using UnityEngine;

[RequireComponent(typeof(Interactable))]
public class StickyNote : MonoBehaviour
{

    [SerializeField][TextArea()] string content;
    Interactable interactable;

    private void Awake()
    {
        interactable = GetComponent<Interactable>();
        interactable.OnInteraction += OpenStickyNote;
    }

    void OpenStickyNote()
    {
        UIPopUpManager.Instance.OpenPopUp(content);
    }

    private void OnDestroy()
    {
        interactable.OnInteraction -= OpenStickyNote;
    }
}
