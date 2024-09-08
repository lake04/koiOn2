using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TitleUpShadow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMove(new Vector3(960, 500, 0), 1f);
 
    }

}
