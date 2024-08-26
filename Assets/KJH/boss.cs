using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    
    public  float hp = 100f;
    public float ptHp = 10;
    [SerializeField]
    GameObject enemy;
    [SerializeField]
    GameObject bullet;

    public GameObject ak;
    public GameObject ak2;
    Animator anim;
    //스폰 위치
    public  Transform spawn;
    public  Transform bullt;

    //소환 패턴 쿨타임
   // private float coolTime = 5f;
    private float coolTime = 1.5f;
    private float pattern1Time = 2f;
    private bool isAk;

    public ParticleSystem da;
    // Start is called before the first frame update
    void Start()
    {
        da.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        attack();
    
        if (coolTime<=0)
        {
            ak.SetActive(true);
            ak2.SetActive(true);
          /*  Instantiate(bullet, bullt.transform.position, bullt.rotation);*/
            StartCoroutine(pattern1());
                  
        }
        else if(coolTime >=0)
        {
            coolTime -= Time.deltaTime;
           
            ak.SetActive(false);
            ak2 .SetActive(false);
        }
      

        if (hp<=0)
        {
            Destroy(this.gameObject);
        }
    }


    private IEnumerator pattern1()
    {

      
        yield return new WaitForSeconds(2f);
        coolTime = 1.5f;
    }

    private void attack()
    {
        if(pattern1Time>=0)
        {
            pattern1Time -= Time.deltaTime;
        }    
       
        if (pattern1Time <= 0)
        {
            if (hp == 90)
            {
                Instantiate(enemy, spawn.position, spawn.rotation);
                pattern1Time = 2f;
            }

            if (hp == 80)
            { 
                Instantiate(enemy, spawn.position, spawn.rotation);
                pattern1Time = 2f;
            }
            if (hp == 70)
            {
                Instantiate(enemy, spawn.position, spawn.rotation);
                pattern1Time = 2f;
            }
            if (hp == 60)
            {
                Instantiate(enemy, spawn.position, spawn.rotation);
                pattern1Time = 2f;
            }
            if (hp ==50)
            {
                Instantiate(enemy, spawn.position, spawn.rotation);
                pattern1Time = 2f;
            }
            if (hp == 40)
            {
                Instantiate(enemy, spawn.position, spawn.rotation);
                pattern1Time = 2f;
            }
            if (hp == 30)
            {
                Instantiate(enemy, spawn.position, spawn.rotation);
                pattern1Time = 2f;
            }
            if (hp == 20)
            {
                Instantiate(enemy, spawn.position, spawn.rotation);
                pattern1Time = 2f;
            }
            if (hp == 10)
            {
                Instantiate(enemy, spawn.position, spawn.rotation);
                pattern1Time = 2f;
            }
           
        }


    }
    

    public void TakeDamage(int damage)
    {
        hp = hp - damage;
        da.Play();
    }

}
