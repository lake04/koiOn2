using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    
    public  int hp = 100;
 
    [SerializeField]
    GameObject enemy;
    [SerializeField]
    GameObject bullet;

    Animator anim;
    //스폰 위치
    public  Transform spawn;
    public  Transform bulltSp;

    //소환 패턴 쿨타임
   // private float coolTime = 5f;
    private float coolTime = 1.5f;
    private float pattern1Time = 2f;
    private bool isAk;

    private float shakeTime;
    private float shakeIntensity;
    private float camerTime = 0.2f;

    public ParticleSystem da;

    bool hasSpawned = false;
    // Start is called before the first frame update
    void Start()
    {
        da.Stop();
        /*InvokeRepeating("bulltSpawn", 2f, 3f);*/
       
    }

    // Update is called once per frame
    void Update()
    {
        /*attack();*/
        SpawnEnemyAtHP(hp);
        if (coolTime<=0)
        { 
            StartCoroutine(pattern1());       
        }
        else if(coolTime >=0)
        {
            coolTime -= Time.deltaTime;
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
    void SpawnEnemyAtHP(int hp)
    {
        if (hp % 10 == 0 && hp <= 90 && hp >= 10&& !hasSpawned)  // 90부터 10까지 10단위로 체크
        {
            Instantiate(enemy, spawn.position, spawn.rotation);
            pattern1Time = 2f;
            hasSpawned = true;
        }
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

        OnShakeCamera(0.1f, 0.3f);

    }

    public void OnShakeCamera(float shakeTime = 1.0f, float shakeIntensity = 0.1f)
    {
        this.shakeTime = shakeTime;
        this.shakeIntensity = shakeIntensity;

        StopCoroutine("shakebyPosition");
        StartCoroutine("shakebyPosition");
    }
    private IEnumerator shakebyPosition()
    {
        Vector3 startPosition = transform.position;

        while (shakeTime > 0.0f)
        {
            transform.position = startPosition + Random.insideUnitSphere * shakeIntensity;

            shakeTime -= Time.deltaTime;

            yield return null;
        }

        transform.position = startPosition;
    }

    private IEnumerator pattern12()
    {


        yield return new WaitForSeconds(2f);
        coolTime = 1.5f;
    }

    private void bulltSpawn()
    {
        Instantiate(bullet, bulltSp.transform.position, Quaternion.identity);
    }
}
