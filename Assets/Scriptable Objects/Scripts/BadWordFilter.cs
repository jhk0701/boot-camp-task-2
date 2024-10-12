using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System;

[CreateAssetMenu(fileName ="BadWordFilter", menuName = "TaskProject/BadWordFilter")]
public class BadWordFilter : ScriptableObject
{    
    bool isInitialized = false;
    readonly string path = Application.dataPath + "/StreamingAssets/Miscellaneous/BadWord.txt";

    /// 탐색용 맵핑. 탐색 한정 O(1)
    public Dictionary<string, string> BadWords;

    [ContextMenu("ReadFile")]
    public void Initialize()
    {
        if (!File.Exists(path))
        {
            Debug.LogError($"[Error] 필터 파일을 찾을 수 없습니다.\n{path}");
            isInitialized = false;
            return;
        }

        BadWords = new Dictionary<string, string>();
        List<string> wordList = File.ReadLines(path).ToList();
        // Debug.Log(wordList.Count);
        for (int i = 0; i < wordList.Count; i++)
        {
            // Debug.Log($"{i + 1}. {wordList[i]}");
            string clean = wordList[i].TrimEnd();
            if (!BadWords.ContainsKey(clean))
                BadWords.Add(clean, new string('*', clean.Length));
        }

        isInitialized = true;
    }

    [ContextMenu("DebugCheck")]
    public void DebugCheck()
    {
        if(BadWords.Count == 0)
            Initialize();
        
        // Debug.Log(BadWords.Count);
        // Debug.Log(FilterString("씨바")); // **
        // Debug.Log(FilterString("개새끼")); // ***
        // Debug.Log(FilterString("좆같은")); // *같은
    }

    // 테스트케이스는 2~10자로 제한된 환경
    public string FilterString(string testCase)
    {
        if(!isInitialized)
        {
            Debug.LogError("[Error] 필터가 초기화되지 않았습니다. 초기화 후 다시 시도해주세요.");
            return testCase;
        }

        string converted = "";
        testCase = testCase.TrimEnd();   
        for(int i = 0; i < testCase.Length; i++)
        {
            // 슬라이딩 윈도우
            int len = i + 1;
            for(int j = 0; j <= testCase.Length - len; j++)
            {
                string window = testCase.Substring(j, len);
                
                if (BadWords.ContainsKey(window))
                {
                    converted = testCase.Replace(window, BadWords[window]);
                    j = j + len - 1; // 변경 지점의 끝으로 이동
                }
            }
        }

        return converted;
    }
    
    public bool IsVaild(string testCase)
    {
        if(!isInitialized)
        {
            Debug.LogError("[Error] 필터가 초기화되지 않았습니다. 초기화 후 다시 시도해주세요.");
            return true;
        }

        testCase = testCase.TrimEnd();   
        for(int i = 0; i < testCase.Length; i++)
        {
            int len = i + 1;
            for(int j = 0; j <= testCase.Length - len; j++)
            {
                string window = testCase.Substring(j, len);
                
                if (BadWords.ContainsKey(window))
                    return false;
            }
        }
        return true;
    }
}
