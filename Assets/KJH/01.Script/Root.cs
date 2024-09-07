using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�� �Ծ����� �����ϴ� �ڵ�
public class Root : MonoBehaviour
{
    [SerializeField]
    private int currentRoot = 0;

    public int CurrentRoot
    {
        set => currentRoot = Mathf.Max(0, value);
        get => currentRoot;
    }
}
