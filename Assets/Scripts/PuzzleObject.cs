using UnityEngine;

public class PuzzleObject : MonoBehaviour
{
    public enum PuzzleType { Snake, Hexagons, Towers, Squares, Vase }
    public PuzzleType type;

    [Header("Only for Library Vase Puzzle")]
    public int vaseNumber; // The number (0–9) this vase represents
}


