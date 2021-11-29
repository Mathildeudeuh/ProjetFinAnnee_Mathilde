using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerBehaviour))]

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D body2D;
    private PlayerAnimations animations;
    private bool canJump = false;
    [SerializeField] private float jump;
    [SerializeField] LayerMask layer;

    public void Jumping()
    {
        if (canJump == true)
        {
            body2D.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
        }
    }

    private void Start()
    {
        body2D = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        var touch = Physics2D.Raycast(transform.position, new Vector2(0, -1), 0.55f, layer);

        if (touch.collider != null)
        {
            canJump = true;
        }

        else
        {
            canJump = false;
        }
    }
}