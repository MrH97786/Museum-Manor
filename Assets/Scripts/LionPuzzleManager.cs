using UnityEngine;

public class LionPuzzleManager : MonoBehaviour
{
    public Transform[] lions; 
    public Vector3[] correctRotations; 

    public Animator doorAnimator; 
    public AudioSource solvedSound;

    private int[] currentRotations; // 0 = 0°, 1 = 90°, 2 = 180°, 3 = 270°
    private bool puzzleSolved = false;

    void Start()
    {
        currentRotations = new int[lions.Length];
    }

    public void RotateLion(int index)
    {
        if (puzzleSolved) return;

        currentRotations[index] = (currentRotations[index] + 1) % 4;
        lions[index].Rotate(0, 90, 0);

        CheckPuzzle();
    }

    void CheckPuzzle()
    {
        for (int i = 0; i < lions.Length; i++)
        {
            Vector3 target = correctRotations[i];
            Vector3 current = lions[i].eulerAngles;

            if (Mathf.Abs(Mathf.DeltaAngle(current.y, target.y)) > 1f)
                return;
        }

        puzzleSolved = true;
        if (doorAnimator != null)
            doorAnimator.SetTrigger("Move");

        if (solvedSound != null)
            solvedSound.Play();
    }
}
