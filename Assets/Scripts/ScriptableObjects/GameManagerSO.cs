using ScriptableObjectArchitecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewGameManager", menuName = "Scriptable Objects/Game Manager")]
public class GameManagerSO : ScriptableObject
{
    [SerializeField] private GameStateSO _currentState;

    [Header("Broadcasting Events")]
    [SerializeField] private GameStateSOGameEvent _gameStateChanged;

    private GameStateSO _previousState;

    public GameStateSO CurrentState { 
        get { return _currentState; }
        set {
            if(this._currentState != null)
            {
                this._previousState = this._currentState;
            }

            this._currentState = value;

            if (this._gameStateChanged != null)
            {
                this._gameStateChanged.Raise(value);
            }
        } 
    }

    public void RestorePreviousState()
    {
        this.CurrentState = this._previousState;
    }
}
