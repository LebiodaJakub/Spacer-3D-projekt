using UnityEngine;
using TMPro;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
/// <summary>
/// Interaction System made with this
/// <seealso href="https://youtu.be/b7Yf6BFx6js">tutorial</seealso>
/// </summary>
public class InteractionUIManager : MonoBehaviour
{
    //Singleton statement
    public static InteractionUIManager Instance;
    private void Awake()
    {
        if (Instance && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }



    //Attributes
    [SerializeField] TMP_Text interactionMessage;
    [SerializeField] LocalizeStringEvent localizeStrEvent;

    public void EnableInteractionText(string text)
    {
        interactionMessage.text = "[E]" + text;
        interactionMessage.gameObject.SetActive(true);
    }

    public void EnableInteractionText(LocalizedString locale)
    {
        //localizeStrEvent.StringReference.Add("InteractKey", locale);
        localizeStrEvent.StringReference = locale;
        interactionMessage.gameObject.SetActive(true);
    }

    public void DisableInteractionText()
    {
        interactionMessage.gameObject.SetActive(false);
    }

}
