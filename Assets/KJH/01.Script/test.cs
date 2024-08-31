using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class test : MonoBehaviour
{
    //������ ���� ������ �������� ����

    
    public GameObject rangObject;
    //��ȯ ����
    BoxCollider2D rangeCollider;
    public bool isSp;
    //��ȯ�� ������Ʈ
    public GameObject att;
    private void Awake()
    {
        rangeCollider = rangObject.GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        StartCoroutine(RandomRespawn_Coroutine());
    }
    private void Update()
    {
       
    }

    // Update is called once per frame
    Vector3 Return_RandomPosition()
    {
        Vector3 originPosition = rangObject.transform.position;
        //�ݶ��̴��� ����� �������� bound.size ���
        float range_x = rangeCollider.bounds.size.x;
        float range_y = rangeCollider.bounds.size.y;

        range_x = Random.Range((range_x / 2) * -1, range_x / 2);
        range_y = Random.Range((range_y / 2) * -1, range_y / 2);
        Vector3 RandomPosition = new Vector3(range_x, range_y, 0f);

        Vector3 respawnPosition = originPosition + RandomPosition;
        return respawnPosition;
    }

   

    IEnumerator RandomRespawn_Coroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            GameObject instantCapsul = Instantiate(att, Return_RandomPosition(), Random.rotation);
            
            Destroy(instantCapsul,0.8f);
        }
    }
}

