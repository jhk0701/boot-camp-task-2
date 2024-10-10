using System;
using TMPro;
using UnityEngine;

public class InfoDisplayer : MonoBehaviour
{
    [SerializeField] TMP_Text txtTime;
    // [SerializeField] TMP_Text txtMap;

    private void Start() 
    {
        if(!IsInvoking("UpdateTime"))
            InvokeRepeating("UpdateTime", 0f, 1f);
    }

    void UpdateTime()
    {
        txtTime.text = DateTime.Now.ToString("yyyy/MM/dd tt hh:mm");
    }
}
