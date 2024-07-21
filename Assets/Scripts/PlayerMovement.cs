
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    private Vector3 movement;
    public float speed = 10f;
    public float sensitivity = 2f;
    private float jumpingVelocity = 0f;
    public float jumpForce = 5f;
    private float cameraRotation = 0f;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // player movement
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;
        moveDirection.Normalize();
        movement = moveDirection * speed;

        // player camera rotation
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = -Input.GetAxis("Mouse Y") * sensitivity;
        // for when player is using camera to look up and down -> rotates camera vertically
        cameraRotation += mouseY;
        cameraRotation = Mathf.Clamp(cameraRotation, -90f, 90f);
        // for when player is using camera to look left and right -> rotates camera horizontally
        transform.Rotate(Vector3.up * mouseX);
        Camera.main.transform.localRotation = Quaternion.Euler(cameraRotation, 0f, 0f);

        if (characterController.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                // if player is jumping implements the jump force
                jumpingVelocity = jumpForce;
            }

        }
        else
        {
            // when player isn't jumping used to implement gravity
            jumpingVelocity += Physics.gravity.y * Time.deltaTime;
        }

        // implements the jumping movement to the player - y axis
        movement.y = jumpingVelocity;

        // this is done to so the character controller can actually move
        characterController.Move(movement * Time.deltaTime);

        // if player falls off map they fail the game and load the game over screen
        if (transform.position.y < 0)
        {
            SceneManager.LoadScene("GameOver");
        }

    }

}
