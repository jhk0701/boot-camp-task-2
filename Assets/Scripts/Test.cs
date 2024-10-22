using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    [SerializeField] GameObject go;


    [ContextMenu("Test")]
    public void TestDebug()
    {
        Debug.Log($"layerMask.value : {layerMask.value}");      // 64
        Debug.Log($"go.layer : {go.layer}");                    // 6
        Debug.Log(IsMatched(layerMask.value, go.layer));        // True
        Debug.Log(LayerMask.NameToLayer("Player") == go.layer); // True
        Debug.Log(layerMask.value == go.layer);                 // False
    }

    bool IsMatched(int val, int layer)
    {
        return val == (val | 1 << layer);
    }
    
    [ContextMenu("SingletonTest")]
    public void SingletonTest()
    {
        Debug.Log(MainManager.Instance.PlayerManager.gameObject);
    }
}
