using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NewBehaviourScript : MonoBehaviour
{
    public Animator animator; // 애니메이션 컨트롤러
    public KeyCode key = KeyCode.LeftShift; // 실행할 키

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
        if (Input.GetKeyDown(KeyCode.LeftShift)) // 지정한 키가 눌리면
        {
            animator.SetTrigger("TitleAnim");// 애니메이션 실행
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
