using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class VasePuzzleManager : MonoBehaviour
{
    public XRSocketInteractor[] sockets; // Six sockets, assign in inspector
    public int[] correctCode = { 4, 0, 2, 5, 3, 6 };

    public Animator doorAnimator;
    public AudioSource puzzleSolvedSound;

    private bool puzzleSolved = false;

    void Update()
    {
        if (puzzleSolved) return;

        if (IsCorrectCodePlaced())
        {
            puzzleSolved = true;
            OnPuzzleSolved();
        }
    }

    bool IsCorrectCodePlaced()
    {
        for (int i = 0; i < sockets.Length; i++)
        {
            if (!sockets[i].hasSelection)
                return false;

            var interactable = sockets[i].firstInteractableSelected;
            if (interactable == null)
                return false;

            var puzzleObj = interactable.transform.GetComponent<PuzzleObject>();
            if (puzzleObj == null || puzzleObj.type != PuzzleObject.PuzzleType.Vase)
                return false;

            if (puzzleObj.vaseNumber != correctCode[i])
                return false;
        }

        return true;
    }

    void OnPuzzleSolved()
    {
        if (doorAnimator != null)
            doorAnimator.SetTrigger("Open");

        if (puzzleSolvedSound != null)
            puzzleSolvedSound.Play();
    }
}

