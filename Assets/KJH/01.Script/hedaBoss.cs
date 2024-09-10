using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hedaBoss : MonoBehaviour
{
    [SerializeField]
    public int hp = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        hp = hp - damage;
       /* da.Play();*/

     

    }
}
