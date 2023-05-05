using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRenderer : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private SpriteRenderer spriteRenderer;


    private bool _isLookingLeft { get { return spriteRenderer.flipX; } }

    public void OnMovement(InputAction.CallbackContext callbackContext)
    {
        Vector2 movementInput = callbackContext.ReadValue<Vector2>();

        if(movementInput.x > 0f && _isLookingLeft)
        {
            spriteRenderer.flipX = false;
        } else if (movementInput.x < 0f && !_isLookingLeft)
        {
            spriteRenderer.flipX = true;
        }

    }
}
