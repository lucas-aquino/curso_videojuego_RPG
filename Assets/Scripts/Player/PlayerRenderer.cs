using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRenderer : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private SpriteRenderer _spriteRenderer;


    private bool IsLookingLeft { get { return _spriteRenderer.flipX; } }

    public void OnMovement(InputAction.CallbackContext callbackContext)
    {
        Vector2 movementInput = callbackContext.ReadValue<Vector2>();

        if(movementInput.x > 0f && IsLookingLeft)
        {
            _spriteRenderer.flipX = false;
        } else if (movementInput.x < 0f && !IsLookingLeft)
        {
            _spriteRenderer.flipX = true;
        }

    }
}
