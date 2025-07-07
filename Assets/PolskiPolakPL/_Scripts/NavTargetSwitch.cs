using UnityEngine;

public class NavTargetSwitch : MonoBehaviour
{
    [SerializeField] Navigation navigation;
    [SerializeField] KeyCode setMarkerButton = KeyCode.E;

    Transform target;
    BetterTransform navParent;

    private void Start()
    {
        navParent = new BetterTransform(transform);
        target = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(setMarkerButton))
        {
            SwitchNavTagret();
        }
    }

    void SwitchNavTagret()
    {
        target = navParent.GetNextChild();
        navigation.Target = target;
    }
}
