using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }

    public KeyCode InteractionKey = KeyCode.E;
    public KeyCode EscapeKey = KeyCode.Escape;
}
