using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCText : MonoBehaviour
{
    [SerializeField]
    private Speaker[] speakers;
    [SerializeField]
    private DialogDate[] dialogs;
    [SerializeField]
    private bool isAutoStart = true;
    private bool isFirst = true;
    private int currentDialogIndex = -1;
    private int currentSpeakerIndex = 0;
    [SerializeField]
    public GameObject ui;
    private bool isInRange = false; // 플레이어가 NPC 영역에 들어왔는지 여부를 확인하는 플래그

    private void Awake()
    {
        Setup();
    }

    // Update는 실행 상호작용을 위한 코드
    public void Update()
    {
        if (isInRange && isFirst)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isFirst = false;
                ui.SetActive(true);
                UpdateDialog();
            }
        }
        else if (!isFirst)
        {
            UpdateDialog();
        }
    }

    // e 코드 상용하기 위한 범위 지정
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            ui.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            ui.SetActive(false);
        }
    }

    // UI 창 꺼주는 역할
    private void Setup()
    {
        for (int i = 0; i < speakers.Length; ++i)
        {
            SetActiveObjects(speakers[i], false);
        }
    }

    // 내용 화살표 눌렀을 때 넘어가는 역할 꺼지는 역할
    public bool UpdateDialog()
    {
        if (isAutoStart && currentDialogIndex == -1)
        {
            SetNextDialog();
        }

        if (Input.GetMouseButton(0))
        {
            if (dialogs.Length > currentDialogIndex + 1)
            {
                SetNextDialog();
            }
            else
            {
                for (int i = 0; i < speakers.Length; ++i)
                {
                    SetActiveObjects(speakers[i], false);
                }
                ui.SetActive(false);
                isFirst = true;
            }
        }

        return false;
    }

    // 다음 대화 설정
    private void SetNextDialog()
    {
        if (currentDialogIndex >= 0)
        {
            SetActiveObjects(speakers[dialogs[currentDialogIndex].speakerIndex], false);
        }
        currentDialogIndex++;
        if (currentDialogIndex < dialogs.Length)
        {
            int speakerIndex = dialogs[currentDialogIndex].speakerIndex;
            SetActiveObjects(speakers[speakerIndex], true);
            speakers[speakerIndex].textName.text = dialogs[currentDialogIndex].name;
            speakers[speakerIndex].textDialogue.text = dialogs[currentDialogIndex].dialogue;
        }
    }

    // 투명한 것
    private void SetActiveObjects(Speaker speaker, bool visible)
    {
        speaker.imageDialog.gameObject.SetActive(visible);
        speaker.textName.gameObject.SetActive(visible);
        speaker.textDialogue.gameObject.SetActive(visible);
        speaker.objectArrow.SetActive(visible);
    }
}

[System.Serializable]
public struct Speaker
{
    public Image imageDialog;
    public TextMeshProUGUI textName;
    public TextMeshProUGUI textDialogue;
    public GameObject objectArrow;
}

[System.Serializable]
public struct DialogDate
{
    public int speakerIndex;
    public string name;
    [TextArea(3, 5)]
    public string dialogue;
}