using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogTest : MonoBehaviour
{
    [SerializeField]
    private NPCText dialogSystem01;
    [SerializeField]
    private TextMeshProUGUI textCountDown;
    [SerializeField]
    private NPCText dialogSystem02;

    private IEnumerator start()
    {
        textCountDown.gameObject.SetActive(false);
    

        yield return new WaitUntil(() => dialogSystem01.UpdateDialog());
        textCountDown.gameObject.SetActive(true);
        int count = 5;
        while(count > 0)
        {
            textCountDown.text = count.ToString();
            count--;

            yield return new WaitForSeconds(1);
        }
        textCountDown.gameObject.SetActive(false);

        yield return new WaitUntil(() => dialogSystem02.UpdateDialog());

        textCountDown.gameObject.SetActive(true);
        textCountDown.text = "The End";

        yield return new WaitForSeconds(2);

        UnityEditor.EditorApplication.ExitPlaymode();

    }

}
