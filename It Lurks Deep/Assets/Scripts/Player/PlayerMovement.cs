using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed;
    public PlayerInputActions playerMovement;

    Vector2 moveDirection = Vector2.zero;
    private InputAction move;

    private void Awake()
    {
        playerMovement = new PlayerInputActions();
    }

    private void OnEnable()
    {
        move = playerMovement.Player.Move;
        move.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
    }

    void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(0, 0, moveDirection.y * moveSpeed);

    }
}
