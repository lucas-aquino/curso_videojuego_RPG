using UnityEngine;

[CreateAssetMenu(fileName = "NewGameState", menuName = "Scriptable Objects/Game State")]
public class GameStateSO : ScriptableObject
{
    [SerializeField] private string _stateName;
    
    public string StateName { get { return _stateName; } }
}
