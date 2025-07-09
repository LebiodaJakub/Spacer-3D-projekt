using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NavigationDropdownScript : MonoBehaviour
{
    TMP_Dropdown locationsDropdown;
    [SerializeField] Transform targetsParent;

    private void Awake()
    {
        locationsDropdown = GetComponent<TMP_Dropdown>();
        InitDropdown();
    }


    void InitDropdown()
    {
        locationsDropdown.ClearOptions();
        List<string> options = new List<string>();
        options.Add("None");
        foreach (Transform child in targetsParent)
        {
            options.Add(child.name);
        }
        locationsDropdown.AddOptions(options);
    }

    public void DrawPath()
    {
        int optionID = locationsDropdown.value;
        if(optionID == 0)
        {
            NavigationSystem.Instance.SetNewTarget(null);
            NavigationSystem.Instance.ShowPath(false);
        }
        else
        {

            Transform target = targetsParent.GetChild(optionID - 1);
            NavigationSystem.Instance.SetNewTarget(target);
            NavigationSystem.Instance.ShowPath(true);
        }
    }

    public void TeleportPlayer()
    {
        Transform playerT = GameManager.Instance.Player.transform;
        int optionID = locationsDropdown.value;
        if (optionID == 0)
        {
            return;
        }
        else
        {
            Transform target = targetsParent.GetChild(optionID - 1);
            playerT.position = target.position;
        }
    }
}
