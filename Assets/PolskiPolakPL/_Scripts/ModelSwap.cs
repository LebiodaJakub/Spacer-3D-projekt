using UnityEngine;

public class ModelSwap : MonoBehaviour
{
    BetterTransform parent;

    // Start is called before the first frame update
    void Start()
    {
        parent = new BetterTransform(transform);
        UpdateShownModel(transform.GetChild(0));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            UpdateShownModel(parent.GetNextChild());
        }
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            UpdateShownModel(parent.GetPreviousChild());
        }
    }

    void UpdateShownModel(Transform target)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
            if(child== target)
                child.gameObject.SetActive(true);
        }
    }
}