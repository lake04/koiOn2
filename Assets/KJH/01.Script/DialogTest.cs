using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogTest : MonoBehaviour
{
    [SerializeField]
    private NPCText dialogSystem01;
    [SerializeField]
    private NPCText dialogSystem02;

    private IEnumerator start()
    {

    

        yield return new WaitUntil(() => dialogSystem01.UpdateDialog());
        int count = 5;
        while(count > 0)
        {
            yield return new WaitForSeconds(1);
        }



    }

}
