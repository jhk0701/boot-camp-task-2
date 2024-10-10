using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerList : MonoBehaviour, IPopUpable
{
    [SerializeField] GameObject panel;
    [SerializeField] Transform list;

    [Header("UI")]
    [SerializeField] TMP_Text txtTitle;
    [SerializeField] TMP_Text txtElement;
    [SerializeField] TMP_Text[] txtInsts;

    void Start()
    {
        txtInsts = new TMP_Text[PlayerManager.MAX_PLAYER_COUNT];
        for (int i = 0; i < PlayerManager.MAX_PLAYER_COUNT; i++)
        {
            TMP_Text inst = Instantiate(txtElement, list);
            txtInsts[i] = inst;
        }
    }

    public void PopUp()
    {
        panel.SetActive(true);

        txtTitle.text = $"Task 02 ({ MainManager.Instance.PlayerManager.players.Count }/{ PlayerManager.MAX_PLAYER_COUNT })";

        int i = 0;
        foreach (Player player in MainManager.Instance.PlayerManager.players)
        {
            // 도중에 사라지는 상황에 대한 처리
            if(player == null) continue;

            txtInsts[i].text = player.PlayerName;
            txtInsts[i].gameObject.SetActive(true);

            i++;
        }
    }

    public void Close()
    {
        for (int i = 0; i < txtInsts.Length; i++)
            txtInsts[i].gameObject.SetActive(false);

        panel.SetActive(false);
    }
}
