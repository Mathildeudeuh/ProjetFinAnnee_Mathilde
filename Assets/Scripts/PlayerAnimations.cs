using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMove))]
[RequireComponent(typeof(PlayerJump))]
public class PlayerAnimations : MonoBehaviour
{
    private Rigidbody2D body2D;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        body2D = GetComponent<Rigidbody2D>(); 
    }

    public void MoveOnPerformed()
    {
        var horizontalSpeed = Mathf.Abs(body2D.velocity.x);
        animator.SetFloat("Speed", horizontalSpeed);
    }

    public void JumpOnPerformed()
    {
        animator.SetBool("Jump", true);
    }
}
