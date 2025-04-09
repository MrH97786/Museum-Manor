using UnityEngine;
using UnityEngine.XR;

public class XRPositionFix : MonoBehaviour
{
    public Vector3 desiredPosition;  
    public Quaternion desiredRotation;

    void Start()
    {
        transform.position = desiredPosition;
        transform.rotation = desiredRotation;
    }
}

