using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

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


    private void Awake()
    {
        Setup();
    }
    //update는 실행상호작용을 위한 코드
    public void Update()
    {
        if (isFirst)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isFirst = false;
                ui.SetActive(true);
                UpdateDialog();
            }
        }
        if (!isFirst)
        {
            UpdateDialog();
        }
    }
    //e코드 상용하기 위한 범위 지정
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("Player"))
        {
            ui.SetActive(true);
            isFirst = true;
        }
        else
        {
            ui.SetActive(false);
        }
    }


    //ui창 꺼주는 역할
    private void Setup()
    {
        for(int i=0; i<speakers.Length; ++i)
        {
            SetActiveObjects(speakers[i], false);
        }
    }

    //내용 화살표 눌렀을 떄 넘어가는 역할 꺼지는 역할
    public bool UpdateDialog()
    {
        if(isAutoStart && currentDialogIndex == -1)
        {
            //Setup();
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
                for(int i =0; i<speakers.Length; ++i)
                {
                    SetActiveObjects(speakers[i], false);
                    
                }
                ui.SetActive(false);
                isFirst = true;
            }
        }

        return false;

    }
    //동일 동일
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
        /*SetActiveObjects(speakers[currentDialogIndex], false);
        currentDialogIndex++;
        currentDialogIndex = dialogs[currentDialogIndex].speakerIndex;
        SetActiveObjects(speakers[currentDialogIndex], false);
        speakers[currentDialogIndex].textName.text = dialogs[currentDialogIndex].name;
        speakers[currentDialogIndex].textDialogue.text = dialogs[currentDialogIndex].dialogue;
        */
    }
    //투명한거 
    private void SetActiveObjects(Speaker speaker, bool visible)
    {
        speaker.imageDialog.gameObject.SetActive(visible);
        speaker.textName.gameObject.SetActive(visible);
        speaker.textDialogue.gameObject.SetActive(visible);
        speaker.objectArrow .SetActive(visible);
        

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
