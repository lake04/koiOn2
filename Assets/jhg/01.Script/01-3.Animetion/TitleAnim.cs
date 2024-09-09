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
        // ��: 3�ʰ� ��� �� ����
        await Task.Delay(3000);
        // �ʱ�ȭ �۾�
        Debug.Log("Initialization Complete");
    }

    private void Update()
    {
        if (!isInitialized) return;
        // �ִϸ��̼� �� ī�޶� ��鸲
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetTrigger("Run");

        }
    }

   
}
