using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByPosition : MonoBehaviour
{
    //화면 밖 일정 범위를 벗어날을 떄 삭제하기 위한 가중치 값
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
