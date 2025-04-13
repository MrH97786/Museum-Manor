using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class KeycardController : MonoBehaviour
{
    public XRSocketInteractor socket;
    public Animator doorAnimator;
    public string openTriggerName = "Open"; 

    public Transform instantRotateDoor; // This is for RoomOneDoor2 upstairs
    public Vector3 openRotationEuler = new Vector3(0f, 420.534f, 0f); 

    private bool isActivated = false;

    public AudioSource doorOpenSound;

    void Update()
    {
        if (isActivated) return;

        if (socket.hasSelection)
        {
            isActivated = true;
            ActivateDoor();
        }
    }

    void ActivateDoor()
    {
        if (doorAnimator != null)
        {
            doorAnimator.SetTrigger(openTriggerName);
        }

        if (instantRotateDoor != null)
        {
            instantRotateDoor.rotation = Quaternion.Euler(openRotationEuler);
        }

        if (doorOpenSound != null)
        {
            doorOpenSound.Play();
        }

    }
}
