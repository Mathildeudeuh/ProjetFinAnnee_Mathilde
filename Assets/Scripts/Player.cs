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
        
    }

    private void MoveOnCanceled(InputAction.CallbackContext obj)
    {

    }

    private void JumpOnPerformed(InputAction.CallbackContext obj)
    {

    }


    void Start()
    {

    }


    void Update()
    {
        
    }
}
