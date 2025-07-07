using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "budynek",menuName = "ScriptableObject/BuildingData")]
public class BuildingData : ScriptableObject
{
    public int BuildingID;
    public string Name;
    public List<string> InstitutesList;
    [Header("Address")]
    public string StreetName;
    public string BuildingNumber;
    public string ApartmentNmber;
    public string PostalCode;
    public string CityName;
}
