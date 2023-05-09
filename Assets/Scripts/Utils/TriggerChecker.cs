using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerChecker : MonoBehaviour
{
    [Header("Extra Config")]
    [SerializeField] private string _validTag;

    [Header("Events")]
    [SerializeField] private UnityEvent _onTriggerEnter;
    [SerializeField] private UnityEvent _onTriggerStay;
    [SerializeField] private UnityEvent _onTriggerExit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_validTag))
        {
            if (_onTriggerEnter != null)
            {
                _onTriggerEnter.Invoke();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag(_validTag))
        {
            if (_onTriggerStay != null)
            {
                _onTriggerStay.Invoke();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(_validTag))
        {
            if (_onTriggerExit != null)
            {
                _onTriggerExit.Invoke();
            }
        }
    }

}
