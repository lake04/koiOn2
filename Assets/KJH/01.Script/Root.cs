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
            // 포인트를 증가시키고, 최대 포인트 수에 도달했는지 확인
            if (pointsCollected < MaxPoints)
            {
                pointsCollected++;
                CurrentRoot++;  // 포인트 증가
                Destroy(collision.gameObject);  // 충돌된 게임 오브젝트 삭제
            }
        }
    }
}
