using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Loading : MonoBehaviour, IPopUpable
{
    float percent = 0f;
    public float Percent 
    { 
        get { return percent; }
        set 
        {
            if(value < 0f || value > 100f)
                return;

            percent = value;

            imgFill.fillAmount = percent;
            txtPercent.text = string.Format("{0:N2} %", percent * 100f);
        }
    }
    
    [SerializeField] GameObject panel;
    [SerializeField] Image imgFill;
    [SerializeField] TMP_Text txtPercent;

    public void PopUp()
    {
        panel.SetActive(true);

        Percent = 0f;
    }

    public void Close()
    {
        panel.SetActive(false);

        Percent = 100f;
    }
}
