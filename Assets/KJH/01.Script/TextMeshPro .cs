using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//UI텍스트 증감 코드
public class TextMeshPro : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textPlayerHP;
    [SerializeField]
    private TextMeshProUGUI textRoot;
    [SerializeField]
    private player playerHP;
    [SerializeField]
    private Root root;
   

    private void Update()
    {
        textPlayerHP.text = playerHP.CurrentHP + "/" + playerHP.MaxHP;
      
    }
}