using UnityEngine;
using ScriptableObjectArchitecture;

public class SceneLoader : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private SceneSO _sceneToLoad;
    [SerializeField] private LevelEntranceSO _levelEntrance;
    [SerializeField] private bool _loadingScreen;

    [Header("Player Path")]
    [SerializeField] private PlayerPathSO _playerPath;

    [Header("Broadcasting Event")]
    [SerializeField] private LoadSceneRequestGameEvent _loadSceneEvent;

    public void LoadScene()
    {
        if(this._levelEntrance != null && this._playerPath != null)
        {
            this._playerPath.LevelEntrance = this._levelEntrance;
        }

        LoadSceneRequest req = new LoadSceneRequest(
            scene: this._sceneToLoad, 
            loadingScreen: this._loadingScreen
        );

        this._loadSceneEvent.Raise(req);
    }
}
