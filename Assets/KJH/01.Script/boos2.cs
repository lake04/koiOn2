using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boos2 : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private Vector3 moveDirection;
    [SerializeField]
   
    // Update is called once per frame
    void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

  public void  MoveTO(Vector3 direction)
    {
        moveDirection = direction;
    }


}
