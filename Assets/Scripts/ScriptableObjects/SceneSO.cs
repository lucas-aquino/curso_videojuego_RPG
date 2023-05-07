using UnityEngine;

[CreateAssetMenu(fileName = "NewScene", menuName = "Scriptable Objects/Scene")]
public class SceneSO : ScriptableObject
{
    [Header("Scene Information")]
    [SerializeField] private string _sceneName;

    public string SceneName { get { return this._sceneName; } }
}
