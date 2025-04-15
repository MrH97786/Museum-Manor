using UnityEngine;

public class LionButton : MonoBehaviour
{
    public LionPuzzleManager manager;
    public int lionIndex; // Assign 0, 1, 2, or 3 in inspector

    public void OnButtonPressed()
    {
        manager.RotateLion(lionIndex);
    }
}

