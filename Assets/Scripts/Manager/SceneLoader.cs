using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public const int START_SCENE = 0;
    public const int GAME_SCENE = 1;

    /// <summary>
    /// 씬 로드 함수
    /// </summary>
    /// <param name="sceneId"></param>
    public void Load(int sceneId, Action onLoadEnd = null)
    {
        StartCoroutine(LoadScene(sceneId, onLoadEnd));
    }

    IEnumerator LoadScene(int sceneId, Action onLoadEnd = null)
    {
        // AsyncOperation async = SceneManager.LoadSceneAsync(sceneId);

        yield return SceneManager.LoadSceneAsync(sceneId);

        onLoadEnd?.Invoke();
    }
}
