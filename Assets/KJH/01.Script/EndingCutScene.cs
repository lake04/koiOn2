using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCutScene : MonoBehaviour
{
    [SerializeField]
    private string playerTag = "Player";  // 플레이어 태그
    [SerializeField]
    private KeyCode triggerKey = KeyCode.E;  // 컷씬을 시작할 키
    [SerializeField]
    private float detectionRadius = 5f;  // 플레이어 탐지 반경
    [SerializeField]
    private GameObject cutsceneObject;  // 컷씬을 제어할 객체 (예: 컷씬 매니저)

    private bool isPlayerInRange = false;

    private void Update()
    {
        // 키 입력을 통해 컷씬을 시작
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
            // 컷씬 시작 코드 예시
            // cutsceneObject.GetComponent<CutsceneManager>().PlayCutscene();
            Debug.Log("Cutscene started!");
        }
    }
}
