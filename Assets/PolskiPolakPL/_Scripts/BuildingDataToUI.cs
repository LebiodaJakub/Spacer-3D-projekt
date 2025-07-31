using TMPro;
using UnityEngine;
using UnityEngine.Localization.Components;

public class BuildingDataToUI : MonoBehaviour
{
    [SerializeField] BuildingData buildingData;
    [SerializeField] TMP_Text nameTextfield;
    [SerializeField] TMP_Text addressTextfield;
    LocalizeStringEvent localizeStringEvent;
    // Start is called before the first frame update
    void Start()
    {
        localizeStringEvent = nameTextfield.gameObject.GetComponent<LocalizeStringEvent>();
        nameTextfield.text = buildingData.name;
        localizeStringEvent.StringReference = buildingData.LocaleStringName;
        addressTextfield.text = CompileAddress(buildingData);
    }

    public static string CompileAddress(BuildingData buildingData)
    {
        string appartmentnumber = buildingData.ApartmentNmber;
        string address = "";

        address += $"{buildingData.StreetName} {buildingData.BuildingNumber}";
        if (appartmentnumber != null && appartmentnumber != "")
            address += $"/{appartmentnumber} ";
        address += $",\n{buildingData.PostalCode} {buildingData.CityName}";
        return address;
    }
}
