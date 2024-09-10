using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//축 먹었을때 증가하는 코드
public class Root : MonoBehaviour
{
    [SerializeField]
    private int currentRoot = 0;

    public void CurrentRoot()
    {
        currentRoot++;
    }
}
