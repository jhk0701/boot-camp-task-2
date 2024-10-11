using UnityEngine;
using TMPro;

public class NonPlayer : Character
{
    [SerializeField] string NpcName;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI txtName;

    void Start()
    {
        Name = NpcName;
        txtName.text = Name;

        // 과제 내용에 따른 추가
        MainManager.Instance.PlayerManager.players.Add(this);    
    }

}