using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectedBuildingScript : MonoBehaviour
{
    [SerializeField] BuildingUIScript buildingScript;
    BuildingData currentBuildingData;
    [SerializeField] TMP_Text nameTextField;
    [SerializeField] TMP_Text addressTextField;
    [Header("Instytutes")]
    [SerializeField] Transform instytutesListContainer;
    [SerializeField] GameObject instytuteTemplate;
    private void Awake()
    {
        BuildingUIScript.OnBuildingChanged += ChangeBuildingScript;
    }
    private void Start()
    {
        ChangeBuildingScript(buildingScript);
    }

    void ChangeBuildingScript(BuildingUIScript newBuildingUIScript)
    {
        buildingScript = newBuildingUIScript;
        currentBuildingData = buildingScript.BuildingData;
        nameTextField.text = currentBuildingData.Name;
        addressTextField.text = buildingScript.CompileAddress(currentBuildingData);
        GenerateInstitutesList(currentBuildingData);
    }


    private void OnDestroy()
    {
        BuildingUIScript.OnBuildingChanged -= ChangeBuildingScript;
    }

    void GenerateInstitutesList(BuildingData buildingData)
    {
        ClearChildrenIn(instytutesListContainer);
        List<string> institutesList = buildingData.InstitutesList;
        GameObject instytuteGO;
        int i = 0;
        foreach (string institute in institutesList)
        {
            instytuteGO = instytutesListContainer.GetChild(i).gameObject;
            ChangeTextIn(instytuteGO, institute);
            instytuteGO.SetActive(true);
            i++;
        }
    }

    void ClearChildrenIn(Transform parent)
    {
        foreach(Transform child in parent)
            child.gameObject.SetActive(false);
    }

    void ChangeTextIn(GameObject targetGO, string newText)
    {
        TMP_Text targetTextField = targetGO.GetComponent<TMP_Text>();
        targetTextField.text = newText;
    }
}
