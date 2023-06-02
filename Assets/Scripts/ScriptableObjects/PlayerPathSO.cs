using UnityEngine;

[CreateAssetMenu(fileName = "PlayerPath", menuName = "Scriptable Objects/Player Path")]
public class PlayerPathSO : ScriptableObject
{
    [SerializeField] private LevelEntranceSO _levelEntrance;

    public LevelEntranceSO LevelEntrance { 
        get { return this._levelEntrance; } 
        set { this._levelEntrance = value; } 
    }
}
