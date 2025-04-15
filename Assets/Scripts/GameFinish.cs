using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameFinish : MonoBehaviour
{
    public XRSocketInteractor socket;
    public Animator doorAnimator;
    public string openTriggerName = "Open"; 

    private bool isActivated = false;

    public AudioSource doorOpenSound;
    public FadeScreen fadeScreen; 

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

        StartCoroutine(EndGameSequence());
    }

    IEnumerator EndGameSequence()
    {
        yield return new WaitForSeconds(7f); // Optional delay before fade
        if (fadeScreen != null)
        {
            fadeScreen.FadeOut();
        }

        yield return new WaitForSeconds(fadeScreen.fadeDuration + 0.5f); // Wait for fade to finish

        SceneManager.LoadScene("1 Start Scene"); // Loads your start scene
    }
}
