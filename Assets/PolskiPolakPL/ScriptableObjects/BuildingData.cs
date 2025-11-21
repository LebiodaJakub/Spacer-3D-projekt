using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "budynek",menuName = "ScriptableObject/BuildingData")]
public class BuildingData : ScriptableObject
{
    public int BuildingID;
    public string Name;
    public LocalizedString LocaleStringName;
    [TextArea] public string Description;
    public LocalizedString DescriptionLocalizedString;
    [Header("Address")]
    public string StreetName;
    public string BuildingNumber;
    public string ApartmentNmber;
    public string PostalCode;
    public string CityName;
}
