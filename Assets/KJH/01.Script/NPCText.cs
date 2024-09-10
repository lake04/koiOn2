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
    private bool isInRange = false; // �÷��̾ NPC ������ ���Դ��� ���θ� Ȯ���ϴ� �÷���

    private void Awake()
    {
        Setup();
    }

    // Update�� ���� ��ȣ�ۿ��� ���� �ڵ�
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

    // e �ڵ� ����ϱ� ���� ���� ����
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

    // UI â ���ִ� ����
    private void Setup()
    {
        for (int i = 0; i < speakers.Length; ++i)
        {
            SetActiveObjects(speakers[i], false);
        }
    }

    // ���� ȭ��ǥ ������ �� �Ѿ�� ���� ������ ����
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

    // ���� ��ȭ ����
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

    // ������ ��
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