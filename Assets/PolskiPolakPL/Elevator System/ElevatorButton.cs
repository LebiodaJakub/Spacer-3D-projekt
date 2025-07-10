using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
public class ElevatorButton : MonoBehaviour
{
    Interactable interactable;
    public int FloorLevel;
    [SerializeField] ElevatorScript elevator;

    private void Awake()
    {
        interactable = GetComponent<Interactable>();
        interactable.OnInteraction += SelectFloor;
    }

    public void SelectFloor()
    {
        if (elevator.TargetLevel == FloorLevel)
            return;
        elevator.TargetLevel = FloorLevel;
        elevator.Close();
    }

    private void OnDestroy()
    {
        interactable.OnInteraction -= SelectFloor;
    }
}
