using ScriptableObjectArchitecture;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class LoadingScreenUI : MonoBehaviour
{
    [Header("Broadcasting on channels")]
    [SerializeField] private BoolGameEvent loadingScreenToggled;

    private Animator _animator;

    private void Awake()
    {
        this._animator = GetComponent<Animator>();
    }

    public void ToggleScreen(bool enable)
    {
        if (!enable)
        {
            this._animator.SetTrigger("Hide");
        }
        else
        {
            this._animator.SetTrigger("Show");
        }

    }

    public void SendLoadingScreenShowEvent()
    {
        loadingScreenToggled.Raise(true);
    }

    public void SendLoadingScreenHiddenEvent()
    {
        loadingScreenToggled.Raise(false);
    }
}
