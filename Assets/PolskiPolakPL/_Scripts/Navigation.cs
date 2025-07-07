using System;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(LineRenderer))]
public class Navigation : MonoBehaviour
{
    public Transform Origin;
    public Transform Target;
    public float StoppingDistance=0.1f;

    public event Action OnTargetReached;

    [SerializeField] float refreshTime = 0.1f;
    [SerializeField] float heightOffset = 0.2f;
    [SerializeField] LineRenderer lineRenderer;

    PolskiPolakPL.Utils.Timer refreshTimer;
    NavMeshPath path;


    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        path = new NavMeshPath();
        refreshTimer = new PolskiPolakPL.Utils.Timer(refreshTime, true);
        refreshTimer.OnTimerEnd += RefreshPath;
        refreshTimer.OnTimerEnd += HandleTargetReachedEvent;
    }

    private void Update()
    {
        refreshTimer.Tick(Time.deltaTime);
    }

    void RefreshPath()
    {
        if (!Target || !Origin)
            return;
        if (!NavMesh.CalculatePath(Origin.position, Target.position,NavMesh.AllAreas, path))
        {
            Debug.LogWarning($"Unable to calculate path between {Origin.position} and {Target.position}!");
            return;
        }
        DrawPath(path);
    }

    void HandleTargetReachedEvent()
    {
        if (Vector3.Distance(Origin.position, Target.position) <= StoppingDistance)
        {
            Debug.Log("Target Reached!");
            OnTargetReached?.Invoke();
        }
    }

    void DrawPath(NavMeshPath path)
    {
        lineRenderer.positionCount = path.corners.Length;
        for (int i = 0; i < path.corners.Length; i++)
        {
            lineRenderer.SetPosition(i, path.corners[i] + Vector3.up * heightOffset);
        }
    }

    private void OnDestroy()
    {
        refreshTimer.OnTimerEnd -= RefreshPath;
        refreshTimer.OnTimerEnd -= HandleTargetReachedEvent;
    }
}