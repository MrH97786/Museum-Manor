using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class PuzzleBallController : MonoBehaviour
{
    public XRLever lever;  
    public XRJoystick joyStick;  
    public XRKnob knob;  

    public float moveSpeed;  
    public float verticalSpeed;

    private Rigidbody rb;

    void Start()
    {
        // Initialize the Rigidbody component 
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Checks if the lever is "on" 
        if (lever.value)
        {
            // Joystick movement 
            float horizontal = joyStick.value.x; // Left/Right on the joystick
            float forward = joyStick.value.y;   // Forward/Backward on the joystick

            // Wheel movement 
            float verticalVelocity = verticalSpeed * Mathf.Lerp(-1, 1, knob.value); // Up/Down based on knob

            // Calculate the movement vector for joystick (horizontal/forward)
            Vector3 joystickMovement = new Vector3(horizontal, 0, forward) * moveSpeed;

            // Apply the vertical velocity from the knob 
            Vector3 knobMovement = new Vector3(0, verticalVelocity, 0);

            // Combine both movements
            Vector3 finalMovement = joystickMovement + knobMovement;

            // Applying the final movement to the object's Rigidbody(stop it from juttering)
            rb.linearVelocity  = finalMovement;
        }
    }
}
