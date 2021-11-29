using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    private PlayerMove playerMove;
    private float moveLR;

    private Rigidbody2D body2D;
    private SpriteRenderer sprite;
    private PlayerAnimations animations;
    private PlayerJump playerJump;

    void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        playerMove = GetComponent<PlayerMove>();
    }

    public void MoveOnPerformed(InputAction.CallbackContext obj)
    {
        if (!obj.performed) return;
        animations.MoveOnPerformed();
        moveLR = obj.ReadValue<float>();
        sprite.flipX = (moveLR < 0);
    }

    private void FixedUpdate()
    {
        playerMove.Move(moveLR);

    }

    public void JumpOnPerformed(InputAction.CallbackContext obj)
    {
        if (!obj.performed) return;
        animations.MoveOnPerformed();
        playerJump.Jumping();
    }
}