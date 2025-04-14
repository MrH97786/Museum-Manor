using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class KeycardSocket : MonoBehaviour
{
    public XRSocketInteractor socket;
    public Animator drawAnimator;
    public string openTriggerName = "Open";

    private bool isActivated = false;

    public AudioSource drawOpenSound;

    void Update()
    {
        if (isActivated) return;

        if (socket.hasSelection)
        {
            isActivated = true;
            ActivateDraw();
        }
    }

    void ActivateDraw()
    {
        if (drawAnimator != null)
        {
            drawAnimator.SetTrigger(openTriggerName);
        }

        if (drawOpenSound != null)
        {
            drawOpenSound.Play();
        }
    }
}

