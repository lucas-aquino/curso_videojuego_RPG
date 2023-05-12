using ScriptableObjectArchitecture;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameStateListener : MonoBehaviour
{
    [Header("Listening to Events")]
    [SerializeField] private GameStateSOGameEvent _gameStateChangedEvent;

    [Header("Enabled & Disabled Shortcuts")]
    [SerializeField] private MonoBehaviour[] _components;
    [SerializeField] private List<GameStateSO> _enabledStates;
    [SerializeField] private List<GameStateSO> _disabledStates;

    [Header("Actions")]
    [SerializeField] private UnityEvent _onMainMenuState;
    [SerializeField] private UnityEvent _onLoadingState;
    [SerializeField] private UnityEvent _onPlayingState;
    [SerializeField] private UnityEvent _onPausedState;

    private void OnEnable()
    {
        this._gameStateChangedEvent?.AddListener(this.GameStateChanged);
    }

    private void OnDisable()
    {
        this._gameStateChangedEvent?.RemoveListener(this.GameStateChanged);
    }

    private void GameStateChanged(GameStateSO gameState)
    {
        this.InvokeShortcuts(gameState);
        this.InvokeActions(gameState);
    }

    private void InvokeShortcuts(GameStateSO gameState)
    {
        foreach (var component in _components)
        {
            if(this._enabledStates.Contains(gameState))
            {
                component.enabled = true;
            }

            if (this._disabledStates.Contains(gameState))
            {
                component.enabled = false;
            }
        }
    }

    private void InvokeActions(GameStateSO gameState)
    {
        if (gameState.StateName.Equals("Main Menu"))
        {
            this._onMainMenuState?.Invoke();
        }

        if (gameState.StateName.Equals("Loading"))
        {
            this._onLoadingState?.Invoke();
        }

        if (gameState.StateName.Equals("Playing"))
        {
            this._onPlayingState?.Invoke();
        }

        if (gameState.StateName.Equals("Paused"))
        {
            this._onPausedState?.Invoke();
        }
    }
}
