using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCutScene : MonoBehaviour
{
    [SerializeField]
    private string playerTag = "Player";  // �÷��̾� �±�
    [SerializeField]
    private KeyCode triggerKey = KeyCode.E;  // �ƾ��� ������ Ű
    [SerializeField]
    private float detectionRadius = 5f;  // �÷��̾� Ž�� �ݰ�
    [SerializeField]
    private GameObject cutsceneObject;  // �ƾ��� ������ ��ü (��: �ƾ� �Ŵ���)

    private bool isPlayerInRange = false;

    private void Update()
    {
        // Ű �Է��� ���� �ƾ��� ����
        if (isPlayerInRange && Input.GetKeyDown(triggerKey))
        {
            StartCutscene();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            isPlayerInRange = false;
        }
    }

    private void StartCutscene()
    {
        if (cutsceneObject != null)
        {
            // �ƾ� ���� �ڵ� ����
            // cutsceneObject.GetComponent<CutsceneManager>().PlayCutscene();
            Debug.Log("Cutscene started!");
        }
    }
}
