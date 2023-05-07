using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderManager : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private LoadingScreenUI loadingScreen;

    private LoadSceneRequest _pendingRequest;


    public void OnLoadMenuRequest(LoadSceneRequest req)
    {
        if (!IsSceneAlreadyLoaded(req.scene))
        {
            SceneManager.LoadScene(req.scene.SceneName);
        }
    }

    public LoadingScreenUI GetLoadingScreen()
    {
        return loadingScreen;
    }

    public void OnLoadLevelRequest(LoadSceneRequest req)
    {
        if (!IsSceneAlreadyLoaded(req.scene))
        {
            if (!req.loadingScreen)
            {
                StartCoroutine(ProcessLevelLoading(req));
                return;
            }
            this._pendingRequest = req;
            this.loadingScreen.ToggleScreen(true);
            return;
        }
        ActivateLevel(req);
    }

    public void OnLoadingScreenToggled(bool enabled)
    {   
        if(enabled && this._pendingRequest != null)
        {
            StartCoroutine(ProcessLevelLoading(this._pendingRequest));
        }
    }

    private IEnumerator ProcessLevelLoading(LoadSceneRequest req)
    {
        if (req.scene != null)
        {
            Scene currentLoadedLevel = SceneManager.GetActiveScene();
            SceneManager.UnloadSceneAsync(currentLoadedLevel);

            AsyncOperation loadSceneProcess = SceneManager.LoadSceneAsync(req.scene.SceneName, LoadSceneMode.Additive);

            while (!loadSceneProcess.isDone)
            {
                yield return null;
            }

            ActivateLevel(req);
        }
    }
        
    private void ActivateLevel(LoadSceneRequest req)
    {
        Scene loadedLevel = SceneManager.GetSceneByName(req.scene.SceneName);
        SceneManager.SetActiveScene(loadedLevel);

        if (req.loadingScreen)
        {
            this.loadingScreen.ToggleScreen(false);
        }
        this._pendingRequest = null;
    }

    private bool IsSceneAlreadyLoaded(SceneSO scene)
    {
        Scene loadedScene = SceneManager.GetSceneByName(scene.SceneName);
        return loadedScene != null && loadedScene.isLoaded;
    }
}
