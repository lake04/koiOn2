using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textPlayerHP;
    [SerializeField]
    private TextMeshProUGUI textRoot;
    [SerializeField]
    private player playerHP;
    [SerializeField]
    private Root root;

    private int currentPoints = 0;
    [SerializeField]
    private int pointsToTriggerAction = 100; // 특정 포인트 수

    private void Update()
    {
        // UI 업데이트
        textPlayerHP.text = playerHP.CurrentHP + "/" + playerHP.MaxHP;
        textRoot.text = root.CurrentRoot.ToString();

        // 포인트가 특정 값에 도달했는지 확인
        CheckPoints();
    }

    // 포인트를 증가시키는 메서드
    public void AddPoints(int amount)
    {
        currentPoints += amount;
        // UI 업데이트를 위해 추가할 수 있음
        Debug.Log("Points: " + currentPoints);
    }

    // 특정 포인트에 도달했을 때 실행할 코드
    private void CheckPoints()
    {
        if (currentPoints >= pointsToTriggerAction)
        {
            TriggerAction();
            currentPoints = 0; // 포인트 초기화
        }
    }

    private void TriggerAction()
    {
        // 포인트 도달 시 실행할 코드
        Debug.Log("Points reached! Triggering action...");
        // 예: 특정 이벤트 호출
    }
}
