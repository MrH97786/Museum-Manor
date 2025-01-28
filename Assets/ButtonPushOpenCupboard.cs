using Unity.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ButtonPushOpenCupboard : MonoBehaviour
{
    public Animator animator1; // First Animator
    public string boolName1 = "Open";

    public Animator animator2; // Second Animator
    public string boolName2 = "Open";

    void Start()
    {
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(x => ToggleCupboardDoors());
    }

    public void ToggleCupboardDoors()
    {
        // Toggle first animator's door
        bool isOpen1 = animator1.GetBool(boolName1);
        animator1.SetBool(boolName1, !isOpen1);

        // Toggle second animator's door
        bool isOpen2 = animator2.GetBool(boolName2);
        animator2.SetBool(boolName2, !isOpen2);
    }
}
