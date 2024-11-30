using UnityEngine;

public class HoleInStone : MonoBehaviour
{
    private void Start()
    {
        GetComponent<TriggerZone>().OnEnterEvent.AddListener(InsideHole);
    }
    public void InsideHole(GameObject obj)
    {
        obj.SetActive(false);
    }
}
