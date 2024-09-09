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
    private int pointsToTriggerAction = 100; // Ư�� ����Ʈ ��

    private void Update()
    {
        // UI ������Ʈ
        textPlayerHP.text = playerHP.CurrentHP + "/" + playerHP.MaxHP;
        textRoot.text = root.CurrentRoot.ToString();

        // ����Ʈ�� Ư�� ���� �����ߴ��� Ȯ��
        CheckPoints();
    }

    // ����Ʈ�� ������Ű�� �޼���
    public void AddPoints(int amount)
    {
        currentPoints += amount;
        // UI ������Ʈ�� ���� �߰��� �� ����
        Debug.Log("Points: " + currentPoints);
    }

    // Ư�� ����Ʈ�� �������� �� ������ �ڵ�
    private void CheckPoints()
    {
        if (currentPoints >= pointsToTriggerAction)
        {
            TriggerAction();
            currentPoints = 0; // ����Ʈ �ʱ�ȭ
        }
    }

    private void TriggerAction()
    {
        // ����Ʈ ���� �� ������ �ڵ�
        Debug.Log("Points reached! Triggering action...");
        // ��: Ư�� �̺�Ʈ ȣ��
    }
}
