using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private Transform cameraTransform;


    private int jumpCount = 0;
    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
        if (isGrounded)

        {
             jumpCount = 0;
            velocity.y = -2f;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveDirection = cameraTransform.forward * vertical + cameraTransform.right * horizontal;
        moveDirection.y = 0;
        if (moveDirection.magnitude > 1)
        {
            moveDirection.Normalize();
        }
        controller.Move(moveDirection * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && jumpCount < 2)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * Physics.gravity.y * 0.5f);
            jumpCount++;
        }

         velocity.y += Physics.gravity.y * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);




    }
}
