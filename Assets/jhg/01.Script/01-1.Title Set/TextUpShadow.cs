using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextUpShadow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 위치 이동 후 크기 변경
        transform.DOMove(new Vector3(1040, 160, 0), 1f);

    }

}
