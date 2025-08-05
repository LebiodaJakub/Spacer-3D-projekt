using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LanguageSelector : MonoBehaviour
{
    TMP_Dropdown dropdown;
    static int currentLocaleID = 0;
    bool active = false;

    private void Awake()
    {
        dropdown = GetComponent<TMP_Dropdown>();
    }

    private void Start()
    {
        dropdown.SetValueWithoutNotify(currentLocaleID);
    }
    public void ChangeLocale(int localeID)
    {
        if (active)
            return;
        StartCoroutine(SetLocale(localeID));
    }

    IEnumerator SetLocale(int localeID)
    {
        active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeID];
        currentLocaleID = localeID;
        active = false;
    }
}
