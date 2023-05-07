using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneInitializer : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private SceneSO[] sceneDependencies;

    [Header("On Scene Ready")]
    [SerializeField] private UnityEvent onDependenciesLoaded;

    private void Start()
    {
        StartCoroutine(LoadDependencies());
    }

    private IEnumerator LoadDependencies()
    {
        foreach (SceneSO sceneToLoad in this.sceneDependencies)
        {
            if (!SceneManager.GetSceneByName(sceneToLoad.SceneName).isLoaded)
            {
                AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneToLoad.SceneName, LoadSceneMode.Additive);

                while (!loadOperation.isDone)
                {
                    yield return null;
                }
            }
        }

        if (onDependenciesLoaded != null)
            onDependenciesLoaded.Invoke();
    }
}
