using UnityEngine;
using TMPro;
using UnityEngine.Events;
public class UIPopUpManager : MonoBehaviour
{
    //Singleton
    public static UIPopUpManager Instance;
    [SerializeField] UnityEvent OnPopUpOpen;
    [SerializeField] UnityEvent OnPopUpClose;

    [SerializeField] TMP_Text contentTextField;
    private void Awake()
    {
        if (Instance && Instance!=this)
            Destroy(this);
        else
            Instance = this;
    }

    public void OpenPopUp()
    {
        Cursor.lockState = CursorLockMode.Confined;
        OnPopUpOpen?.Invoke();
    }
    public void OpenPopUp(string text)
    {
        contentTextField.text = text;
        Cursor.lockState = CursorLockMode.Confined;
        OnPopUpOpen?.Invoke();
    }
    public void ClosePopUp()
    {
        Cursor.lockState -= CursorLockMode.Locked;
        OnPopUpClose?.Invoke();
    }
}
