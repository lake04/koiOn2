using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NewBehaviourScript : MonoBehaviour
{
    public Animator animator; // �ִϸ��̼� ��Ʈ�ѷ�
    public KeyCode key = KeyCode.LeftShift; // ������ Ű

    private void Awake()
    {
        animator = GetComponent<Animator>();

    }
    public void Close()
    {
        StartCoroutine(CloseAfterDelay());
    }

    private IEnumerator CloseAfterDelay()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) // ������ Ű�� ������
        {
            animator.SetTrigger("TitleAnim");// �ִϸ��̼� ����
            yield return new WaitForSeconds(0.5f);
            gameObject.SetActive(false);
            animator.ResetTrigger("TitleAnim");
        }
        
    }
    public void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SceneManager.LoadScene("KJH");
        }
    }


}
