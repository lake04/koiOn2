using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class player : MonoBehaviour
{
    [Header("player")]
    public float moveSpeed = 5f;
    public float defaultSpeed = 10f;//달리기
    public bool isJump;
    public float jumpPower = 10f;
    //플래이어HP정보
    [Header("PlayerHP")]
    [SerializeField]
    private Image imageScreen;
    [SerializeField]
    private float maxHP = 6;
    private float currentHP;
    public float MaxHP => maxHP;
    public float CurrentHP => currentHP;


    //공격
    [Header("attack")]
    private float curTime;
    public Transform pos;
    public Transform pos2;
    public Vector2 boxSize;

    //피격 이펙트
    [SerializeField]
    private GameObject damagepnel;
    private bool isDamge = false;

    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer spriteRenderer;
    private new Collider2D Collider2D;

    //카메라 흔들림
    private float shakeTime;
    private float shakeIntensity;
    private float camerTime = 0.2f;

    //무적
    private bool isInvincible = false;
    private float invincibleDuration = 2.0f; // 무적 상태 유지 시간 (예: 2초)

    [Header("사운드")]
    private AudioSource HitAudi;
    private AudioSource JumpAudi;
    private AudioSource ActAudi;


    private void Awake()
    {
        HitAudi = GetComponents<AudioSource>()[2];
        JumpAudi = GetComponents<AudioSource>()[1];
        ActAudi = GetComponents<AudioSource>()[0];
        currentHP = maxHP;
    }
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
        Die();

        //점프
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("isJump", true);
            if (isJump)
            {
                JumpAudi.Play();
                rb.velocity = Vector2.up * jumpPower;
                isJump = false;

            }
        }
        attack();

        //씬이동
        if (currentHP <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        //이동 제한 범위 보스전때 쓸거 (머리카락 보스) 이거로 머리카란 보스 랜덤으로 머리카락 떨어지는 패턴 구현
        float x = Mathf.Clamp(transform.position.x, Constants.min.x, Constants.max.x);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
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
            HitAudi.Play();
            currentHP--;
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
        if (collision.gameObject.tag == "boss")
        {
            isJump = true;

        }
        //피격
        if (collision.gameObject.tag == "attack" && isDamge == false)
        {
            HitAudi.Play();
            currentHP--;
            /*StopCoroutine("HitAlphaAnimation");
            StartCoroutine("HitAlphaAnimation");*/
            //무적 타임
            OnDamged(collision.transform.position);
            //카메라 흔들기
            OnShakeCamera(0.1f, 1f);

            damagepnel.SetActive(true);
            StartCoroutine(coolTime());
            StartCoroutine(damgePanel());
        }


    }

    private void Die()
    {
        if (currentHP <= 0)
        {
            HitAudi.Play();
            anim.SetBool("isDie", true);

            Invoke("seen", 2f);
        }
    }
    private void seen()
    {
        SceneManager.LoadScene("Title2.0");
    }

    private void attack()
    {

        if (Input.GetKeyDown(KeyCode.RightShift) && curTime <= 0)
        {
            anim.SetBool("isAttack", true);
            if (spriteRenderer.flipX == true)
            {
                Collider2D[] collider2D = Physics2D.OverlapBoxAll(pos2.position, boxSize, 0);
                foreach (Collider2D collider in collider2D)
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
                Debug.Log("2");
                curTime = 0.5f;
                //Invoke("outatt", 0.5f);

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
                curTime = 0.5f;
                /*Invoke("outatt", 1f);*/
            }
        }

        if (curTime >= 0)
        {
            curTime = curTime - Time.deltaTime;

        }
        else
        {
            anim.SetBool("isAttack", false);
        }
    }

    private void OnDrawGizmos()
    {//공격 범위
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
    {//데미지 패널 쿨타임
        yield return new WaitForSeconds(camerTime);

        damagepnel.SetActive(false);
        camerTime = 0.2f;
    }
    //카메라
    public void OnShakeCamera(float shakeTime = 1.0f, float shakeIntensity = 0.1f)
    {
        this.shakeTime = shakeTime;
        this.shakeIntensity = shakeIntensity;

        StopCoroutine("shakebyPosition");
        StartCoroutine("shakebyPosition");
    }

    //카메라
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
        isDamge = true;
        //Change layer (Immprtal Active)
        gameObject.layer = 9;

        //View Alpha
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);

        Invoke("OffDamged", 3);
    }
    void OffDamged()
    {
        isDamge = false;
        gameObject.layer = 11;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }



}