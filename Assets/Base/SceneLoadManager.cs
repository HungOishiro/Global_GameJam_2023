using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SceneLoadManager : SingletonMonoBehaviour<SceneLoadManager>
{
    public bool isLoading;
    public bool isUnloading;

    private readonly string nameSceneGamePlay = "GamePlay";
    private readonly string nameSceneHome = "Home";

    public void LoadSceneWithName(string name)
    {
        LoadAsyncScene(name);
    }

    // public void LoadCurrentScene()
    // {
    //     string name = SceneManager.GetActiveScene().name;

    //     LoadSceneWithName(name);
    // }

    public void LoadSceneHome()
    {
        LoadAsyncScene(nameSceneHome);
    }

    public void LoadSceneGamePlay()
    {
        LoadAsyncScene(nameSceneGamePlay);
    }

    // public void LoadSceneLevel(int index)
    // {
    //     if (index > GameConfig.TotalLevel)
    //     {
    //         index = GameConfig.TotalLevel;
    //     }

    //     LoadSceneWithName(nameSceneGamePlay + index);
    // }

    #region LoadSceneAsync
    private void LoadAsyncScene(string name)
    {
        isLoading = true;
        StartCoroutine(WaitLoadAsyncScene(name));
    }

    private IEnumerator WaitLoadAsyncScene(string name)
    {
        Debug.Log("Scene " + name + " is loading...");

        yield return new WaitForSecondsRealtime(0.5f);

        var asyncLoad = SceneManager.LoadSceneAsync(name);

        while (asyncLoad == null || !asyncLoad.isDone) yield return null;

        if (isLoading)
        {
            isLoading = false;

            Debug.Log("Scene " + name + " is loaded!!!");
        }
    }


    public void UnloadSceneWithName(string name, Action _callBack = null)
    {
        UnloadAsyncScene(name, _callBack);
    }
    private void UnloadAsyncScene(string name, Action _callBack = null)
    {
        isUnloading = true;
        StartCoroutine(WaitUnloadScene(name, _callBack));
    }

    private IEnumerator WaitUnloadScene(string name, Action _callBack = null)
    {
        var asyncLoad = SceneManager.UnloadSceneAsync(name);

        while (!asyncLoad.isDone) yield return null;

        if (isUnloading)
        {
            isUnloading = false;

            _callBack?.Invoke();

            Debug.Log("Scene " + name + " is unloaded!!!");
        }
    }

    #endregion
}