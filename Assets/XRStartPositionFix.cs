using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;

public class XRStartPositionFix : MonoBehaviour
{
    public XROrigin xrOrigin;
    public Transform playerStartPoint;

    void Start()
    {
        if (xrOrigin != null && playerStartPoint != null)
        {
            xrOrigin.MoveCameraToWorldLocation(playerStartPoint.position);
        }
    }
}

