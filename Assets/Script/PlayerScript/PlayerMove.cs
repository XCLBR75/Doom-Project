using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float playerSpeed = 10f;
    public float moemntumDamping = 5f;
    private CharacterController myCC;
    public Animator camAnim;
    private bool isWalking;

    private Vector3 inputVector;
    private Vector3 movementVector;
    private float myGravity = -10f;
    // Character Controller Settings
    public float stepOffset = 0.4f; // Adjust as per your stair height
    public float slopeLimit = 45f; // Maximum climbable slope angle
    public float skinWidth = 0.08f; // Adjust to avoid collision issues

    // Start is called before the first frame update
    void Start()
    {
        myCC = GetComponent<CharacterController>();

        // Adjust Character Controller settings
        if (myCC != null)
        {
            myCC.stepOffset = stepOffset;
            myCC.slopeLimit = slopeLimit;
            myCC.skinWidth = skinWidth;
        }
    }
    // Update is called once per frame
    void Update()
    {
        GetInput();
        MovePlayer();

        camAnim.SetBool("isWalking", isWalking);
    }

    void GetInput()
    {
        if (Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.D))
        {
            inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            inputVector.Normalize();
            inputVector = transform.TransformDirection(inputVector);

            isWalking = true;
        }
        else
        {

            inputVector = Vector3.Lerp(inputVector, Vector3.zero, moemntumDamping * Time.deltaTime);
            isWalking = false;
        }

        movementVector = (inputVector * playerSpeed) + (Vector3.up * myGravity);
    }

    void MovePlayer()
    {
        myCC.Move(movementVector * Time.deltaTime);
    }
}
