using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("PlayerScript Movement")]
    [SerializeField] float playerSpeed = 5f;
    
    [Header("PlayerScript Jump")]
    [SerializeField] float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = Physics.gravity.y;
    [SerializeField] Vector3 playerVelocity;
    private bool groundedPlayer;
    
    [Header("PlayerScript Look")]
    [SerializeField] Camera playerCamera;
    [SerializeField] float mouseSensitivity = 1f;
    private float xRotation = 0f;


    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y <= 0)
        {
            playerVelocity.y = 0f;
        }
        PlayerMove();
        PlayerLook();
        if (Input.GetButtonDown("Jump") && groundedPlayer)
            PlayerJump();

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    void PlayerMove()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(playerSpeed * Time.deltaTime * move);
    }

    void PlayerLook()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate the player's body left and right
        transform.Rotate(Vector3.up * mouseX);

        // Rotate the camera up and down (clamping to 90 degrees)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    void PlayerJump()
    {
        playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
    }

}
