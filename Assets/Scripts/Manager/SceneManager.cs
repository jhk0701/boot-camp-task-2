using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public const int START_SCENE = 0;
    public const int GAME_SCENE = 1;

    SceneManager sceneManager;

    void Awake()
    {
        if(sceneManager == null)
            sceneManager = new SceneManager();
    }

    /// <summary>
    /// 씬 로드 함수
    /// </summary>
    /// <param name="sceneId"></param>
    public void LoadScene(int sceneId)
    {
        sceneManager.LoadScene(sceneId);
    }
}
