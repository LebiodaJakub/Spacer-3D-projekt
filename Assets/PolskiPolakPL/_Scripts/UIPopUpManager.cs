using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.Localization.Components;
using UnityEngine.Localization;
public class UIPopUpManager : MonoBehaviour
{
    //Singleton
    public static UIPopUpManager Instance;

    [SerializeField] LocalizeStringEvent localStrEvent;
    [SerializeField] TMP_Text contentTextField;
    [SerializeField] UnityEvent OnPopUpOpen;
    [SerializeField] UnityEvent OnPopUpClose;

    private void Awake()
    {
        if (Instance && Instance!=this)
            Destroy(this);
        else
            Instance = this;
    }

    public void OpenPopUp()
    {
        Cursor.lockState = CursorLockMode.None;
        OnPopUpOpen?.Invoke();
    }
    public void OpenPopUp(string text)
    {
        contentTextField.text = text;
        Cursor.lockState = CursorLockMode.None;
        OnPopUpOpen?.Invoke();
    }
    public void OpenPopUp(LocalizedString localizedString)
    {
        if (!localStrEvent)
        {
            Debug.LogWarning("No LocalizeStringEvent in reference! Please attach Event to the reference if you want to use it.");
            return;
        }
        localStrEvent.StringReference = localizedString;
        Cursor.lockState = CursorLockMode.None;
        OnPopUpOpen?.Invoke();
    }
    public void ClosePopUp()
    {
        Cursor.lockState = CursorLockMode.Locked;
        OnPopUpClose?.Invoke();
    }
}
