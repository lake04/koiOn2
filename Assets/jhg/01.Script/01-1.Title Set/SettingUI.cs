using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    [SerializeField]
    private Button MouseControlButton;
    [SerializeField]
    private Button KeyboardMouseControlButton;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();

    }

    private void OnEnable()
    {
        switch (PlayerSettings.controlType)
        {
            case EcontrolType.Mouse:
                MouseControlButton.image.color = Color.green;
                KeyboardMouseControlButton.image.color = Color.white;
                break;

            case EcontrolType.KeyboardMouse:
                MouseControlButton.image.color = Color.green;
                KeyboardMouseControlButton.image.color = Color.white;
                break;
        }
    }

    public void SetControlMode(int controlType)
    {
        PlayerSettings.controlType = (EcontrolType)controlType;

        switch (PlayerSettings.controlType)
        {
            case EcontrolType.Mouse:
                MouseControlButton.image.color = Color.green;
                KeyboardMouseControlButton.image.color = Color.white;
                break;

            case EcontrolType.KeyboardMouse:
                MouseControlButton.image.color = Color.green;
                KeyboardMouseControlButton.image.color = Color.white;
                break;
        }
    }

    public void Close()
    {
        StartCoroutine(CloseAfterDelay());
    }

    private IEnumerator CloseAfterDelay()
    {
        animator.SetTrigger("close");
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
        animator.ResetTrigger("close");
    }

}
