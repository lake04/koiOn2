using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField]
    private int currentRoot = 0;
    private const int MaxPoints = 3;
    private int pointsCollected = 0;

    public int CurrentRoot
    {
        set => currentRoot = Mathf.Max(0, value);
        get => currentRoot;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Root"))
        {
            // ����Ʈ�� ������Ű��, �ִ� ����Ʈ ���� �����ߴ��� Ȯ��
            if (pointsCollected < MaxPoints)
            {
                pointsCollected++;
                CurrentRoot++;  // ����Ʈ ����
                Destroy(collision.gameObject);  // �浹�� ���� ������Ʈ ����
            }
        }
    }
}
