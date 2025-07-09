using System;
using UnityEngine;
using UnityEngine.AI;
using PolskiPolakPL.Utils;

[RequireComponent(typeof(LineRenderer))]
public class NavigationSystem : MonoBehaviour
{
    public NavigationSystem Instance;

    Timer refreshTimer;
    NavMeshPath path;
    LineRenderer lineRenderer;
    private void Awake()
    {
        if(Instance && Instance!=this)
            Destroy(gameObject);
        else
            Instance = this;



        lineRenderer = GetComponent<LineRenderer>();
        path = new NavMeshPath();
        refreshTimer = new Timer(refreshTime, true);
        refreshTimer.OnTimerEnd += RefreshPath;
        refreshTimer.OnTimerEnd += CheckTargetReached;
    }

    [SerializeField] Transform Origin;
    public Transform Target;
    public float StoppingDistance=0.1f;

    public event Action OnTargetReached;

    [SerializeField] float refreshTime = 0.1f;
    [SerializeField] float heightOffset = 0.2f;


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

    void CheckTargetReached()
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
        refreshTimer.OnTimerEnd -= CheckTargetReached;
    }
}