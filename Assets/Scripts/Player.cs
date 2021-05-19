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

    private float move;

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
        var horizontalSpeed = Mathf.Abs(body2D.velocity.x);

        // Si la valeur de horizontalSpeed est inférieur à celle de maxSpeed...
        if (horizontalSpeed < maxSpeed)
            // ... alors on ajoute de la force en multipliant les valeurs de speed et move (que horizontalement)
            body2D.AddForce(new Vector2(speed * move, 0));
    }

    void Update()
    {
        
    }
}
