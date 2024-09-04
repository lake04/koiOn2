using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using Unity.VisualScripting;
using UnityEngine;

public class bosPtennl : MonoBehaviour
{
    [SerializeField]
    private GameObject pt2;
    [SerializeField]
    int ptSpeed;
    private Vector3 dicten;

    public GameObject taget;
    //도착 지점
    public GameObject respawn;

    private float coolTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(coolTime >=0)
        {
            coolTime-= Time.deltaTime;
            StopCoroutine(pttenl3());
        }
        

        if(coolTime <=0 )
        {
            
            StartCoroutine(pttenl3());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("taget"))
        {
            taget.transform.position = respawn.transform.position;
        }
    }

    //보스 기본 공격 지진 느낌
   IEnumerator pttenl3()
    {
        pt2.transform.position += Vector3.right * -ptSpeed * Time.deltaTime;
        
        yield return new WaitForSeconds(1.5f);
        coolTime = 5f;
    }
        

}
