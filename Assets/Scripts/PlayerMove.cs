using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    private Rigidbody2D rb2D;

    public void Move(float direction)
    {
        if (speed < maxSpeed)
        {
            rb2D.AddForce(new Vector2(speed * direction, 0));
        }
    }
}