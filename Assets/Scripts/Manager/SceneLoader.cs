using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public const int SCENE_START = 0;
    public const int SCENE_GAME = 1;

    [SerializeField] Loading loading;

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
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneId);

        if(loading == null)
            yield return async;
        else
        {
            loading.PopUp();

            while (!async.isDone)
            {
                loading.Percent = async.progress;
                yield return null;
            }

            loading.Close();
        }

        onLoadEnd?.Invoke();
    }
}
