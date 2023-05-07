using UnityEngine;

public class LevelEntrance : MonoBehaviour
{
    [SerializeField] private LevelEntranceSO _entrance;

    public LevelEntranceSO Entrance
    {
        get { return this._entrance; }
        set { this._entrance = value; }
    }
}
