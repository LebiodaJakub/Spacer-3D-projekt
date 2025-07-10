using System;
using UnityEngine;
using UnityEngine.AI;
using PolskiPolakPL.Utils;

[RequireComponent(typeof(LineRenderer))]
public class NavigationSystem : MonoBehaviour
{
    public static NavigationSystem Instance;

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

    Transform origin;
    Transform target;
    [SerializeField] float StoppingDistance=0.1f;

    public event Action OnTargetReached;

    [SerializeField] float refreshTime = 0.1f;
    [SerializeField] float heightOffset = 0.2f;

    private void Start()
    {
        origin = GameManager.Instance.Player.transform;
    }


    private void Update()
    {
        refreshTimer.Tick(Time.deltaTime);
    }

    public void SetNewTarget(Transform targetT)
    {
        target = targetT;
    }

    public void ShowPath(bool show)
    {
        lineRenderer.enabled = show;
    }

    void RefreshPath()
    {
        if (!target || !origin)
            return;
        if (!NavMesh.CalculatePath(origin.position, target.position,NavMesh.AllAreas, path))
        {
            Debug.LogWarning($"Unable to calculate path between {origin.position} and {target.position}!");
            return;
        }
        DrawPath(path);
    }

    void CheckTargetReached()
    {
        if (!target || !origin)
            return;
        if (Vector3.Distance(origin.position, target.position) <= StoppingDistance)
        {
            Debug.Log("Target Reached!");
            ShowPath(false);
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