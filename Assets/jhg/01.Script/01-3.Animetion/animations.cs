using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animations : MonoBehaviour
{
    public Animator animator; // 애니메이션 컨트롤러
    public KeyCode key = KeyCode.Space; // 실행할 키

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift)) // 지정한 키가 눌리면
        {
            animator.SetTrigger("Run"); // 애니메이션 실행
        }
    }
}