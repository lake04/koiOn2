using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animations : MonoBehaviour
{
    public Animator animator; // �ִϸ��̼� ��Ʈ�ѷ�
    public KeyCode key = KeyCode.Space; // ������ Ű

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift)) // ������ Ű�� ������
        {
            animator.SetTrigger("Run"); // �ִϸ��̼� ����
        }
    }
}