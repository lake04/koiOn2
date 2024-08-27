using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    Rigidbody2D rb;
    public float hp = 3;
    public int EnMoveSpeed;
    public int nextMove;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
     

        Invoke("Think", 5);
    }

    private void Update()
    {
        if(hp<=0)
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        //move
        rb.velocity = new Vector2(nextMove, rb.velocity.y);

        //platform check
        Vector2 frontVec = new Vector2(rb.position.x + nextMove * 0.3f, rb.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("ground"));
        if (rayHit.collider == null)
            Turn();
    }

    void Think()
    {
        nextMove = Random.Range(-1, 2);

        float nextThinkTime = Random.Range(2f, 5f);
        Invoke("Think", 5);
    }

    void Turn()
    {
        nextMove = nextMove * -1;
       

        CancelInvoke();
        Invoke("Think", 5);
    }

    public void TakeDamage(int damage)
    {
        hp = hp - damage;
       
    }

}
