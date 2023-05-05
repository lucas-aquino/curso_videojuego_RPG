using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimations : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private Animator animator; // Referencia hacia el controlador de animacion

    public void OnMovement(InputAction.CallbackContext callbackContext)
    {
        /*
         Este valor es el que viene del InputAction
         Este valor es Vector2
         Luego usa la funcion magnitude => (float)Math.Sqrt(x * x + y * y) 
         para transformarlo en float a travez de dicha cuenta 
         */
        float movementMagnitude = callbackContext.ReadValue<Vector2>().magnitude;

        animator.SetBool("isRunning", movementMagnitude != 0f);
    }

}
