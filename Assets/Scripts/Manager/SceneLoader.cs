using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public const int SCENE_START = 0;
    public const int SCENE_GAME = 1;

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
