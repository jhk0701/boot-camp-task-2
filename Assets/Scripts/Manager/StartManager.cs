using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 추후 저장 데이터, 로그인 등등 가능하도록 Start 씬 관련 매니저 작성
public class StartManager : MonoBehaviour
{
    public static StartManager Instance { get; private set; }

    public Dictionary<int, IPage> pages = new Dictionary<int, IPage>();

    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;   
        }

        Instance =  this;
    }

    void Start()
    {
        pages[PageStartScene.Hash].Open();
    }
}
