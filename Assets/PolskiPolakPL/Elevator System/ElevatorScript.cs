using System;
using UnityEngine;
using UnityEngine.Events;

public class ElevatorScript : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float elevatorSpeed = 1;
    [SerializeField] Vector3[] floors;
    public int TargetLevel = 0;
    Vector3 targetPos;
    private void Awake()
    {
        targetPos = transform.position;
    }

    public UnityEvent OnElevatorStarted;
    public UnityEvent OnElevateorStopped;
    private void Update()
    {
        if (ElevatorOnTarget())
            return;
        Move();
    }

    public void Open()
    {
        animator.Play("Open Animation");
        OnElevateorStopped?.Invoke();
    }
    public void Close()
    {
        OnElevatorStarted?.Invoke();
        animator.Play("Close Animation");
    }

    public void StartElevator()
    {
        targetPos = floors[TargetLevel];
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, elevatorSpeed * Time.deltaTime);
        if (ElevatorOnTarget())
            Open();
    }

    bool ElevatorOnTarget()
    {
        return transform.position==targetPos;
    }

}
