using UnityEngine;

public class HoleInStone : MonoBehaviour
{
    public Animator stoneAnimator1;
    public Animator stoneAnimator2;
    public AudioSource stoneMoveSound;
    public AudioSource puzzleSolvedSound;

    private void Start()
    {
        GetComponent<TriggerZone>().OnEnterEvent.AddListener(InsideHole);
    }

    public void InsideHole(GameObject obj)
    {
        // Trigger animation
        if (stoneAnimator1 != null)
            stoneAnimator1.SetTrigger("Move");

        if (stoneAnimator2 != null)
            stoneAnimator2.SetTrigger("Move");

        // Play sound
        if (stoneMoveSound != null)
            stoneMoveSound.Play();

        if (puzzleSolvedSound != null)
            puzzleSolvedSound.Play();
    }
}
