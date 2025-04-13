using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PuzzleManager : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor topLeftSocket;
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor topRightSocket;
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor bottomLeftSocket;
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor bottomRightSocket;

    public Animator clockAnimator; 

    private bool puzzleSolved = false;
    //public Renderer puzzleSurface; // for testing purposes
    //public Color solvedColor = Color.green;

    public AudioSource puzzleSolvedSound;
    public AudioSource clockMovingSound;

    void Update()
    {
        if (puzzleSolved) return;

        if (CheckSlot(topLeftSocket, PuzzleObject.PuzzleType.Squares) &&
            CheckSlot(topRightSocket, PuzzleObject.PuzzleType.Snake) &&
            CheckSlot(bottomLeftSocket, PuzzleObject.PuzzleType.Towers) &&
            CheckSlot(bottomRightSocket, PuzzleObject.PuzzleType.Hexagons))
        {
            puzzleSolved = true;
            OnPuzzleSolved();
        }
    }

    bool CheckSlot(UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socket, PuzzleObject.PuzzleType expectedType)
{
    if (socket.hasSelection)
    {
        var interactable = socket.firstInteractableSelected;
        if (interactable != null)
        {
            PuzzleObject puzzleObj = interactable.transform.GetComponent<PuzzleObject>();
            return puzzleObj != null && puzzleObj.type == expectedType;
        }
    }
    return false;
}


    void OnPuzzleSolved()
    {
        //if (puzzleSurface != null)
        //{
        //    puzzleSurface.material.color = solvedColor;
        //}

        if (clockAnimator != null)
        {
            clockAnimator.SetTrigger("Move");
        }

        if (puzzleSolvedSound != null)
        {
            puzzleSolvedSound.Play();
        }

        if (clockMovingSound != null)
        {
            clockMovingSound.Play();
        }

    }
}
