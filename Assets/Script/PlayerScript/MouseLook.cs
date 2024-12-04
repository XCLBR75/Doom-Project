// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class MouseLook : MonoBehaviour
// {
//     public float sensitivity = 1.5f;
//     public float smoothing = 1.5f;
//     private float xMousePos;
//     private float smoothedMousePos;
//     private float currentLookingPos;
//     // Start is called before the first frame update
//     private void Start()
//     {
//         Cursor.lockState = CursorLockMode.Locked;
//         Cursor.visible = false;
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         GetInput();
//         ModifyInput();
//         MovePlayer();
//     }

//     void GetInput()
//     {
//         xMousePos = Input.GetAxisRaw("Mouse X");
//     }

//     void ModifyInput()
//     {
//         xMousePos *= sensitivity * smoothing;
//         smoothedMousePos = Mathf.Lerp(smoothedMousePos, xMousePos, 1f / smoothing);

//     }

//     void MovePlayer()
//     {
//         currentLookingPos += smoothedMousePos;
//         transform.localRotation = Quaternion.AngleAxis(currentLookingPos, transform.up);
//     }
// }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 1.5f; // Mouse sensitivity
    public float smoothing = 1.5f; // Smoothing factor (optional)

    private float xMousePos; // Raw mouse input on the X-axis
    private float yMousePos; // Raw mouse input on the Y-axis
    private float smoothedMousePosX; // Smoothed X-axis input
    private float smoothedMousePosY; // Smoothed Y-axis input
    private float currentLookingPosX = 0f; // Current X-axis (vertical) rotation
    private float currentLookingPosY = 0f; // Current Y-axis (horizontal) rotation

    // Rotation limits for vertical rotation (pitch) to prevent flipping
    public float minVerticalAngle = -80f;
    public float maxVerticalAngle = 80f;

    public static bool isCursorLocked = true; // Tracks whether the cursor is locked
    public static bool shouldRead = true;

    // Start is called before the first frame update
    private void Start()
    {
        Time.timeScale = 1f;
        LockAndHideCursor(); // Initially lock and hide the cursor
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            UnlockAndShowCursor();
            shouldRead = false; // Disable reading of the Return key
        }

        if (!isCursorLocked)
            return;

        GetInput();  // Capture the mouse input
        ModifyInput(); // Apply sensitivity and smoothing
        MovePlayer(); // Apply the rotation to the camera
    }

    // Get mouse input for both X and Y axes
    void GetInput()
    {
        xMousePos = Input.GetAxisRaw("Mouse X"); // Get horizontal (left-right) movement
        yMousePos = Input.GetAxisRaw("Mouse Y"); // Get vertical (up-down) movement
    }

    // Modify the mouse input based on sensitivity and smoothing
    void ModifyInput()
    {
        xMousePos *= sensitivity; // Apply sensitivity to horizontal movement
        yMousePos *= sensitivity; // Apply sensitivity to vertical movement

        smoothedMousePosX = Mathf.Lerp(smoothedMousePosX, xMousePos, 1f / smoothing); // Smooth X input
        smoothedMousePosY = Mathf.Lerp(smoothedMousePosY, yMousePos, 1f / smoothing); // Smooth Y input
    }

    // Apply the movement to the camera rotation
    void MovePlayer()
    {
        // Apply horizontal (left-right) rotation to the player (yaw)
        currentLookingPosY += smoothedMousePosX;
        transform.localRotation = Quaternion.AngleAxis(currentLookingPosY, Vector3.up);

        // Apply vertical (up-down) rotation to the camera (pitch)
        currentLookingPosX -= smoothedMousePosY; // Invert the Y-axis for natural looking up/down
        currentLookingPosX = Mathf.Clamp(currentLookingPosX, minVerticalAngle, maxVerticalAngle); // Clamp the vertical rotation

        // Apply the pitch rotation to the camera
        Camera.main.transform.localRotation = Quaternion.Euler(currentLookingPosX, 0f, 0f);
    }

    // Unlocks and shows the cursor
    public void UnlockAndShowCursor()
    {
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        Cursor.visible = true; // Show the cursor
        isCursorLocked = false;
    }

    // Locks and hides the cursor
    public void LockAndHideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor
        Cursor.visible = false; // Hide the cursor
        isCursorLocked = true;
    }

    // Toggles the cursor lock state
    public void ToggleCursorState()
    {
        if (isCursorLocked)
        {
            UnlockAndShowCursor(); // Unlock and show the cursor
        }
        else
        {
            LockAndHideCursor(); // Lock and hide the cursor
        }
    }
}
