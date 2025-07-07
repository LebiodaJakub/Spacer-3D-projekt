using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuildingUIScript : MonoBehaviour
{
    public BuildingData BuildingData;
    [SerializeField] TMP_Text NameTextField;
    [SerializeField] TMP_Text AddressTextField;
    public static event Action<BuildingUIScript> OnBuildingChanged;

    public string Name {  get; private set; }
    public string Address { get; private set; }
    public int BuildingID { get; private set; }

    private void Start()
    {
        Name = BuildingData.Name;
        BuildingID = BuildingData.BuildingID;
        Address = CompileAddress(BuildingData);
        SetUIInfo();
    }

    void SetUIInfo()
    {
        NameTextField.text = Name;
        AddressTextField.text = Address;
    }

    public string CompileAddress(BuildingData buildingData)
    {
        string appartmentnumber = buildingData.ApartmentNmber;
        string address = "";

        address += $"{buildingData.StreetName} {buildingData.BuildingNumber}";
        if (appartmentnumber != null && appartmentnumber != "")
            address += $"/{appartmentnumber} ";
        address += $",\n{buildingData.PostalCode} {buildingData.CityName}";
        return address;
    }

    public void SetCurrentBuilding()
    {
        OnBuildingChanged?.Invoke(this);
    }
}
