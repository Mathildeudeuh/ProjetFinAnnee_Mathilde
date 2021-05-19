using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // A modifier dans l'inspector
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float jump;
    [SerializeField] LayerMask layer;

    private float move;
    private bool canJump = false;

    // Variable pour utiliser les components
    private Rigidbody2D body2D;
    private SpriteRenderer sprite;
    private Animator animator;

    // Variable pour utiliser les contôles
    private Controls controls;


    private void OnEnable()
    {
        // Instance de la fonction Controls
        controls = new Controls();

        controls.Enable();

        controls.Main.Move.performed += MoveOnPerformed;
        controls.Main.Move.canceled += MoveOnCanceled;
        controls.Main.Jump.performed += JumpOnPerformed;
    }

    private void MoveOnPerformed(InputAction.CallbackContext obj)
    {
        // move prend la valeur du float
        move = obj.ReadValue<float>();

        // Le personnage se retourne quand la valeur de la direction est négative
        sprite.flipX = (move < 0);
    }

    private void MoveOnCanceled(InputAction.CallbackContext obj)
    {
        // Le personnage ne se déplace plus
        move = 0;
    }

    private void JumpOnPerformed(InputAction.CallbackContext obj)
    {
        // Si canJump est vrai...
        if (canJump == true)
            // ... On ajoute de la force qui prend la valeur de jump (verticalement)s
            body2D.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);

        // Le paramètre d'animation "Jump" s'active
        animator.SetBool("Jump", true);
    }


    void Start()
    {
        // body2D doit se référer au component RigidBody2D
        body2D = GetComponent<Rigidbody2D>();

        // sprite doit se référer au component SpriteRenderer
        sprite = GetComponent<SpriteRenderer>();

        // animator doit se référer au component Animator
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        // horizontalSpeed prend la valeur de la vitesse du personnage (horizontalement)
        var horizontalSpeed = Mathf.Abs(body2D.velocity.x);

        // Si la valeur de horizontalSpeed est inférieur à celle de maxSpeed...
        if (horizontalSpeed < maxSpeed)
            // ... alors on ajoute de la force en multipliant les valeurs de speed et move (que horizontalement)
            body2D.AddForce(new Vector2(speed * move, 0));

        // Le paramètre d'animation "Speed" prend la valeur de horizontalSpeed
        animator.SetFloat("Speed", horizontalSpeed);
    }

    void Update()
    {
        // Création d'un raycast qui prend la position du personnage, qui va vers le bas et qui mesure 1 cm
        var touch = Physics2D.Raycast(transform.position, new Vector2(0, -1), 0.001f, 9);

        // Si le le raycast touche un collider...
        if (touch.collider != null)
            // ... le personnage peut sauter
            canJump = true;
        // Sinon...
        else
            // ... le personnage ne peut pas sauter
            canJump = false;
    }
}
