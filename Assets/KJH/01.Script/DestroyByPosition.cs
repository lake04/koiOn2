using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByPosition : MonoBehaviour
{
    //ȭ�� �� ���� ������ ����� �� �����ϱ� ���� ����ġ ��
    private float destroyWeight = 2;
   private void LateUpate()
    {
        if( transform.position.x < Constants.min.x - destroyWeight ||
            transform.position.x > Constants.max.x + destroyWeight ||
            transform.position.y < Constants.min.y - destroyWeight ||
            transform.position.y > Constants.max.x + destroyWeight )
        {
            Destroy(gameObject);
        }
    }
}
