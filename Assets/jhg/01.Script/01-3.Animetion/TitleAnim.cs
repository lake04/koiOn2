using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class TitleAnim : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    private bool isInitialized = false;
    private async void Start()
    {
        await Initialize();
        isInitialized = true;
    }
    private async Task Initialize()
    {
        // 예: 3초간 대기 후 실행
        await Task.Delay(3000);
        // 초기화 작업
        Debug.Log("Initialization Complete");
    }

    private void Update()
    {
        if (!isInitialized) return;
        // 애니메이션 및 카메라 흔들림
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetTrigger("Run");

        }
    }

   
}
