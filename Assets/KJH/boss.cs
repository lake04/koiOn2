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
    //스폰 위치
    public  Transform spawn;

    //소환 패턴 쿨타임
    private float coolTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        attack();
        StartCoroutine(pattern1());
        if(hp<=0)
        {
            Destroy(this.gameObject);
        }
    }


    private IEnumerator pattern1()
    {

       
        yield return new WaitForSeconds(1f);
     
    }

    private void attack()
    {
       
       if(coolTime>=0)
        {
            coolTime-=Time.deltaTime;
        }

        if (coolTime <= 0)
        {
            if (hp == 90)
            {
                Instantiate(enemy, spawn.position, spawn.rotation);
                coolTime = 5f;
            }

            if (hp == 80)
            { 
                Instantiate(enemy, spawn.position, spawn.rotation);
                coolTime = 5f;
            }
            if (hp == 70)
            {
                Instantiate(enemy, spawn.position, spawn.rotation);
                coolTime = 5f;
            }
            if (hp == 60)
            {
                Instantiate(enemy, spawn.position, spawn.rotation);
                coolTime = 5f;
            }
            if (hp ==50)
            {
                Instantiate(enemy, spawn.position, spawn.rotation);
                coolTime = 5f;
            }
            if (hp == 40)
            {
                Instantiate(enemy, spawn.position, spawn.rotation);
                coolTime = 5f;
            }
            if (hp == 30)
            {
                Instantiate(enemy, spawn.position, spawn.rotation);
                coolTime = 5f;
            }
            if (hp == 20)
            {
                Instantiate(enemy, spawn.position, spawn.rotation);
                coolTime = 5f;
            }
            if (hp == 10)
            {
                Instantiate(enemy, spawn.position, spawn.rotation);
                coolTime = 5f;
            }
           
        }


    }
    

    public void TakeDamage(int damage)
    {
        hp = hp - damage;
    }
}
