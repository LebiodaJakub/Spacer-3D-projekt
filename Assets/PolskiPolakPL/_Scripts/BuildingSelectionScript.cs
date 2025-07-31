using UnityEngine;
using TMPro;
using UnityEngine.Localization.Components;

public class BuildingSelectionScript : MonoBehaviour
{
    [SerializeField] BuildingData currentBuildingData;
    [SerializeField] TMP_Text nameTextField;
    [SerializeField] TMP_Text addressTextField;
    [SerializeField] TMP_Text descriptionTextField;
    LocalizeStringEvent nameLocalizeEvent;
    LocalizeStringEvent descriptionLocalizeEvent;
    private void Awake()
    {
        nameLocalizeEvent = nameTextField.gameObject.GetComponent<LocalizeStringEvent>();
        descriptionLocalizeEvent = descriptionTextField.gameObject.GetComponent<LocalizeStringEvent>();
        ChangeBuilding(currentBuildingData);
    }

    public void ChangeBuilding(BuildingData buildingData)
    {
        nameTextField.text = buildingData.Name;
        nameLocalizeEvent.StringReference = buildingData.LocaleStringName;
        addressTextField.text = BuildingDataToUI.CompileAddress(buildingData);
        descriptionTextField.text = buildingData.Description;
        descriptionLocalizeEvent.StringReference = buildingData.DescriptionLocalizedString;
    }
}
