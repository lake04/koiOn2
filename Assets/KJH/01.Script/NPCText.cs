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


    private void Awake()
    {
        Setup();
    }

    void Update()
    {
        if (isAutoStart)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Setup();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isAutoStart = true;


        }



        if (collision.gameObject.tag == "Player")
        {
            ui.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isAutoStart = false;
        ui.SetActive(false);
    }


    private void Setup()
    {
        for(int i=0; i<speakers.Length; ++i)
        {
            SetActiveObjects(speakers[i], false);
            speakers[i].spriteRenderer.gameObject.SetActive(true);
        }
    }

    public bool UpdateDialog()
    {
        if(isFirst == true)
        {
            Setup();
            if (isAutoStart) SetNextDialog();
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
                    SetActiveObjects(speakers[1], false);
                    speakers[i].spriteRenderer.gameObject.SetActive(false);
                }
            }
        }

        return false;

    }
    
    private void SetNextDialog()
    {
        SetActiveObjects(speakers[currentDialogIndex], false);
        currentDialogIndex++;
        currentDialogIndex = dialogs[currentDialogIndex].speakerIndex;
        SetActiveObjects(speakers[currentDialogIndex], false);
        speakers[currentDialogIndex].textName.text = dialogs[currentDialogIndex].name;
        speakers[currentDialogIndex].textDialogue.text = dialogs[currentDialogIndex].dialogue;

    }

    private void SetActiveObjects(Speaker speaker, bool visible)
    {
        speaker.imageDialog.gameObject.SetActive(visible);
        speaker.textName.gameObject.SetActive(visible);
        speaker.textDialogue.gameObject.SetActive(visible);
        speaker.objectArrow .SetActive(visible);
        Color color = speaker.spriteRenderer.color;
        color.a = visible == true ? 1 : 0.2f;
        speaker.spriteRenderer.color = color;

    }

}
[System.Serializable]
public struct Speaker
{
    public SpriteRenderer spriteRenderer;
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
