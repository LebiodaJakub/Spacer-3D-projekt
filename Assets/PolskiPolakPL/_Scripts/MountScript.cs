using UnityEngine;

public class MountScript : MonoBehaviour
{
    Transform prevParent;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player entered!");
        prevParent = other.transform.parent;
        other.transform.parent = transform;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Player left!");
        other.transform.parent = prevParent;
    }
}
