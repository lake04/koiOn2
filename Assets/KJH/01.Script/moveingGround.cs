using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveingGround : MonoBehaviour
{

    public Transform start; //시작 위치
    public Transform end;  //끝 위치
    public Transform desPos;
    

    private float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = start.position;
        desPos = end;
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    private void FixedUpdate()
    {
       transform.position = Vector2.MoveTowards(transform.position, desPos.position,Time.deltaTime * speed);

        if(Vector2.Distance(transform.position, desPos.position) <= 0.0f)
        {
            if(desPos == end) desPos = start;
            else desPos = end;
        }
    }
}
