using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateChanger : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private GameManagerSO _gameManager;

    public GameManagerSO GameManager { get { return this._gameManager; } }

    public void SetGameState(GameStateSO gameState) => this._gameManager.CurrentState = gameState;
    
    public void RestorePreviousState() => this._gameManager.RestorePreviousState();
}
