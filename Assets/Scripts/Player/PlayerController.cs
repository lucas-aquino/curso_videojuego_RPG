using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private float _speed;

    [Header("Dependencies")]
    [SerializeField] private Rigidbody2D _rigidbody;

    public Rigidbody2D Rigidbody { get { return _rigidbody; } }

    private Vector2 _movementInput;

    private void FixedUpdate()
    {
        this._rigidbody.velocity = _movementInput * _speed;
    }

    public void OnMovement(InputAction.CallbackContext callbackContext)
    {
        _movementInput = callbackContext.ReadValue<Vector2>();
    }

}
