using UnityEngine;

[CreateAssetMenu(fileName = "NewScene", menuName = "Scriptable Objects/Scene")]
public class SceneSO : ScriptableObject
{
    [Header("Scene Information")]
    [SerializeField] private string sceneName;
}
