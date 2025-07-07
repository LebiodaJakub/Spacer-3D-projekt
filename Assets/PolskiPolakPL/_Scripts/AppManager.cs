using UnityEngine;
using UnityEngine.SceneManagement;

public class AppManager : MonoBehaviour
{
    public static AppManager Instance;

    private void Awake()
    {
        if (Instance && Instance != this)
            Destroy(this);
        else
            Instance = this;

        if(Application.targetFrameRate != 60)
            Application.targetFrameRate = 60;
    }

    public void LoadScene(int id)
    {
       SceneManager.LoadScene(id);
    }

    public void FreezeTime(bool freeze)
    {
        if (freeze)
            Time.timeScale = 0;
        else Time.timeScale = 1;
    }

    public void LockCursor(bool lockCursor)
    {
        if (lockCursor)
            Cursor.lockState = CursorLockMode.Locked;
        else
            Cursor.lockState = CursorLockMode.None;
    }
}
