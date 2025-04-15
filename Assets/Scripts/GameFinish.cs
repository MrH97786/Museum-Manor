using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class GameFinish : MonoBehaviour
{
    public XRSocketInteractor socket;
    public Animator doorAnimator;
    public string openTriggerName = "Open"; 

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

        if (doorOpenSound != null)
        {
            doorOpenSound.Play();
        }

    }
}

