using UnityEngine;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] KeyCode pauseKey = KeyCode.Escape;
    bool isPaused = false;
    public UnityEvent OnPaused;
    public UnityEvent OnResume;

    private void Awake()
    {
        if(Instance && Instance!=this)
            Destroy(this);
        else
            Instance = this;
    }

    void Update()
    {
        if (!Input.GetKeyDown(pauseKey))
            return;
        if(!isPaused)
            PauseGame();
        else
            ResumeGame();
    }

    public void PauseGame()
    {
        AppManager.Instance.LockCursor(false);
        OnPaused?.Invoke();
        AppManager.Instance.FreezeTime(true);
        isPaused = true;
    }

    public void ResumeGame()
    {
        AppManager.Instance.FreezeTime(false);
        AppManager.Instance.LockCursor(true);
        OnResume?.Invoke();
        isPaused = false;
    }
}
