using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//UI�ؽ�Ʈ ���� �ڵ�
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