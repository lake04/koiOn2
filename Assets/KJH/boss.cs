using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    public float hp = 10f;
    [SerializeField]
    GameObject enemy;
    Animator anim;
    public  Transform spawn;


    private float coolTime = 2f;
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
        if (hp >0 && coolTime <= 0)
        {
            
            hp--;

            Instantiate(enemy, spawn.position, spawn.rotation);
            coolTime = 2f;

        }
        if (coolTime >= 0)
        {
      
            coolTime = coolTime - Time.deltaTime;
        }

    }
}
