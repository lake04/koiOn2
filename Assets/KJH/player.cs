using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    [Header("player")]
    public float moveSpeed = 5f;
    public float defaultSpeed = 10f;//달리기
    public bool isJump;
    public float jumpPower = 10f;
    public int hp = 3;

    [Header("attack")]
    private float curTime;
    public Transform pos;
    public Transform pos2;
    public Vector2 boxSize;

    //피격 이펙트
    [SerializeField]
    private GameObject damagepnel;

    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer spriteRenderer;

    //카메라 흔들림
    private float shakeTime;
    private float shakeIntensity;
    private float camerTime = 0.2f;

    //무적
    private bool isInvincible = false;
    private float invincibleDuration = 2.0f; // 무적 상태 유지 시간 (예: 2초)
    // Start is called before the first frame update
    void Start()
    {
        damagepnel.SetActive(false);
        defaultSpeed = moveSpeed;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("isJump", true);
            if (isJump)
            {
                rb.velocity = Vector2.up * jumpPower;
                isJump = false;
               
            }
        }
        attack();
      
        if(hp <=0)
        {
            SceneManager.LoadScene("Title");
        }
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        if (Input.GetButton("Horizontal"))
        {
            anim.SetBool("isWalk", true);
            float h = Input.GetAxisRaw("Horizontal");
            Vector3 dir = new Vector3(h, 0f, 0f).normalized;
            transform.Translate(dir * defaultSpeed * Time.deltaTime);
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }


        else
        {
            anim.SetBool("isWalk", false);
            anim.SetBool("isJump", false);
        }

        //달리기
        if (Input.GetKey(KeyCode.LeftShift))
        {
            defaultSpeed = 8;
        }
        else
        {
            
            defaultSpeed = moveSpeed;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isJump = true;
        }

        //피격
        if (collision.gameObject.tag == "enemy" && !isInvincible)
        {
            hp--;
            //무적 타임
            OnDamged(collision.transform.position);

            //카메라 흔들기
            OnShakeCamera(0.1f, 1f);

            damagepnel.SetActive(true);
            StartCoroutine(coolTime());
            StartCoroutine(damgePanel());
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.gameObject.tag == "boss")
        {
            isJump = true;
           
        }
        //피격
        if (collision.gameObject.tag == "attack")
        {
            hp--;
            //무적 타임
            OnDamged(collision.transform.position);
            //카메라 흔들기
            OnShakeCamera(0.1f, 1f);
          
            damagepnel.SetActive(true);
            StartCoroutine(coolTime());
            StartCoroutine(damgePanel());
        }

      
    }
      


    private void attack()
    {

        if (Input.GetKeyDown(KeyCode.RightShift) && curTime <= 0)
        {
            if(spriteRenderer.flipX == true)
            {
                Collider2D[] collider2D = Physics2D.OverlapBoxAll(pos2.position, boxSize, 0);
                foreach (Collider2D collider in collider2D)
                {
                    if(collider.tag == "boss")
                    {
                        collider.GetComponent<boss>().TakeDamage(2);
                    }


                    if (collider.tag == "enemy")
                    {
                        collider.GetComponent<bosseEnemy>().TakeDamage(1);
                    }

                }
                Debug.Log("2");
                curTime = 1;
                Invoke("outatt", 1f);

            }
            if (spriteRenderer.flipX == false)
            {
                Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
                foreach (Collider2D collider in collider2Ds)
                {
                    if (collider.tag == "boss")
                    {
                        collider.GetComponent<boss>().TakeDamage(2);
                        
                    }
                    if (collider.tag == "enemy")
                    {
                        collider.GetComponent<bosseEnemy>().TakeDamage(1);
                    }
                }
                Debug.Log("1");
                curTime = 1;
                Invoke("outatt", 1f);
            }
        }

        if (curTime >= 0)
        {
            curTime = curTime - Time.deltaTime;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(pos.position, boxSize);

            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(pos2.position, boxSize);

    }
    IEnumerator coolTime()
    {
        isInvincible = true;  // 무적 상태 시작
        yield return new WaitForSeconds(invincibleDuration);  // 무적 시간 동안 대기
        isInvincible = false;  // 무적 상태 해제
        
    }
    IEnumerator damgePanel()
    {
        yield return new WaitForSeconds(camerTime);
         
         damagepnel.SetActive(false);
         camerTime = 0.2f;
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

    void OnDamged(Vector2 targetPos)
    {
   
        //Change layer (Immprtal Active)
        gameObject.layer = 9;

        //View Alpha
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);

        Invoke("OffDamged", 3);
    }
    void OffDamged()
    {
        gameObject.layer = 11;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }
}