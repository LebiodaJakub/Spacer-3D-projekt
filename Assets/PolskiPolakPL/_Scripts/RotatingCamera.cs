using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCamera : MonoBehaviour
{
    [SerializeField] Transform cameraT;
    [SerializeField] Vector3 camera_offset;
    [SerializeField] Vector3 rotationAngles;

    // Start is called before the first frame update
    void Start()
    {
        if(!cameraT)
            cameraT = transform.GetChild(0);
        cameraT.localPosition = camera_offset;
    }

    // Update is called once per frame
    void Update()
    {

        cameraT.localPosition = camera_offset;
        transform.Rotate(rotationAngles * Time.deltaTime);
        cameraT.LookAt(transform.position);
    }
}
