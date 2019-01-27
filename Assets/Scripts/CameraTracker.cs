using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    public Vector3 cameraOffset;
    public GameObject trackedObject;
    public Vector3 debugCalc;
    // Update is called once per frame
    void Update()
    {
        transform.position = trackedObject.transform.position + cameraOffset;
        debugCalc = transform.position;
}
}
