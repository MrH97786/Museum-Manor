using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class PuzzleMazeController : MonoBehaviour
{
    public XRJoystick joyStick;  
    public float rotationSpeed = 90f;  // Speed 
    private Vector3 objectCenter;

    void Start()
    {
        // Center of the object 
        objectCenter = transform.position;
    }

    void Update()
    {
        float horizontalInput = joyStick.value.x;  // Left/Right on the joystick

        // If there's horizontal input (left or right), rotate the object around its center
        if (Mathf.Abs(horizontalInput) > 0.1f)
        {
            RotateObject(horizontalInput);
        }
    }

    void RotateObject(float horizontalInput)
    {
        float rotationAmount = horizontalInput * rotationSpeed * Time.deltaTime;
        transform.RotateAround(transform.position, Vector3.up, rotationAmount);
    }
  
}


