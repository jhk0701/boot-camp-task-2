using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialoguePlayer : MonoBehaviour, IPopUpable
{
    public DialogueTree Dialogue { get; private set; }
    [SerializeField] GameObject panel;

    // TODO : 추후 확장 시, 버튼 갯수 관련해서 필요하면 동적 생성하도록
    [SerializeField] GameObject buttonEnd;
    [SerializeField] GameObject[] buttonChoices;

    [SerializeField] TMP_Text txtSpeaker;
    [SerializeField] TMP_Text txtContent;
    [SerializeField] CanvasGroup buttonGroup;

    WaitForSeconds waitForDotSecond;
    
    Coroutine dialogueHandler;
    Coroutine buttonAnimHandler;

    [SerializeField] AnimationCurve buttonAnimCurve;

    void Start()
    {
        waitForDotSecond = new WaitForSeconds(0.05f);
    }

    public void PopUp()
    {
        buttonGroup.interactable = false;
        buttonGroup.alpha = 0f;

        panel.SetActive(true);
    }

    public void Close()
    {
        ClearButtonHandler();
        ClearDialogueHandler();

        panel.SetActive(false);
    }

    public void Play(DialogueTree tree)
    {
        Dialogue = tree;
        
        PopUp();

        StartDialogue();
    }


    public void OnClickChoice(int i)
    {
        HideButtons();

        Dialogue.Next(i);

        StartDialogue();
    }

    public void OnClickEnd()
    {
        Close();
    }


    void StartDialogue()
    {
        ClearDialogueHandler();
        dialogueHandler = StartCoroutine(PlayDialogue());
    }

    IEnumerator PlayDialogue()
    {
        DialogueNode node = Dialogue.CurrentNode;

        txtSpeaker.text = Dialogue.Participants[node.participantId];
        txtContent.text = "";
        for (int i = 0; i < node.content.Length; i++)
        {
            txtContent.text += node.content[i];
            yield return waitForDotSecond;
        }

        SetUpButtons();
    }
    
    void ClearDialogueHandler()
    {
        if(dialogueHandler != null)
        {
            StopCoroutine(dialogueHandler);
            dialogueHandler = null;
        }
    }

    void SetUpButtons()
    {   

        if(Dialogue.IsLast())
        {
            for (int i = 0; i < buttonChoices.Length; i++)
                buttonChoices[i].SetActive(false);

            buttonEnd.SetActive(true);
        }
        else
        {
            for (int i = 0; i < buttonChoices.Length; i++)
            {
                bool isOn = i < Dialogue.CurrentNode.response.Length;
                buttonChoices[i].SetActive(isOn);

                if(isOn)
                    buttonChoices[i].GetComponentInChildren<TMP_Text>().text = Dialogue.CurrentNode.response[i].name;
            }

            buttonEnd.SetActive(false);
        }

        ShowButtons();
    }

    void ShowButtons()
    {
        ClearButtonHandler();
        buttonAnimHandler = StartCoroutine(OnOffButtons(true));
    }

    void HideButtons()
    {
        ClearButtonHandler();
        buttonAnimHandler = StartCoroutine(OnOffButtons(false));
    }

    
    IEnumerator OnOffButtons(bool isOn)
    {
        buttonGroup.alpha = isOn ? 0f : 1f;
        buttonGroup.interactable = false;

        float progress = 0f;
        float delta = .05f;
        while (progress <= 1f)
        {
            float val = buttonAnimCurve.Evaluate(progress);
            buttonGroup.alpha += isOn ?  val : -val;

            yield return waitForDotSecond;

            progress += delta;
        }

        buttonGroup.alpha = isOn ? 1f : 0f;
        buttonGroup.interactable = isOn;
    }

    void ClearButtonHandler()
    {
        if(buttonAnimHandler != null)
        {
            StopCoroutine(buttonAnimHandler);
            buttonAnimHandler = null;
        }
    }

}
