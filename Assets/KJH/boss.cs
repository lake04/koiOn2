using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    
    public  float hp = 100f;
    public float ptHp = 10;
    [SerializeField]
    GameObject enemy;
    Animator anim;
    //���� ��ġ
    public  Transform spawn;

    //��ȯ ���� ��Ÿ��
    private float coolTime = 10f;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        attack();
        StartCoroutine(pattern1());
    }


    private IEnumerator pattern1()
    {

       
        yield return new WaitForSeconds(1f);
     
    }

    private void attack()
    {
        if (hp == 90)
        {

            ptHp--;

            Instantiate(enemy, spawn.position, spawn.rotation);

        }
        if (coolTime >= 0)
        {
      
            coolTime = coolTime - Time.deltaTime;
        }

    }

    public void TakeDamage(int damage)
    {
        hp = hp - damage;
    }
}
