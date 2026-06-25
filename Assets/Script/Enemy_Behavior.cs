using UnityEngine;

public class Enemy_Behavior : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer sr;
    private float moveSpeed = 2f;
    private Rigidbody2D rb;
    private Transform pl_target;
    private Vector2 moveDir;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Find the pos of the player with the tag
        //pl_target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Set the animation
        EnemyAnim();
        //This will make the enemy moves towards the player
        if (!playerinArea)
        {
            //If the player is not on the area, enemy is idle
            moveDir = Vector2.zero;
        }
        else
        {
            Vector2 dir = (pl_target.position - transform.position).normalized;
            moveDir = dir; Debug.Log("Enemy is Chasing");
            FlippingSprite();
        }
    }

    void FixedUpdate()
    {
        //Enemy movement physics
        rb.linearVelocity = new Vector2(moveDir.x, moveDir.y) * moveSpeed;
        
    }

    private void FlippingSprite()
    {
        //The sprite will flip facing the player
        if(transform.position.x < pl_target.position.x) //right
        {
            sr.flipX = false;
        }
        else //left
        {
            sr.flipX = true;
        }
    }

    private bool playerinArea;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerinArea = true;
            pl_target = collision.gameObject.transform;
        }   
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")) 
        {
            playerinArea = false;
            pl_target = null;
        }     
    }

    private void EnemyAnim()
    {
        if(rb.linearVelocity.magnitude > 0)
        {
            anim.Play("E chase");   
        }
        else
        {
            anim.Play("E idle");
        }
    }
}
