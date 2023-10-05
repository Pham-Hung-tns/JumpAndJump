using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMove : MonoBehaviour
{
    [Header("Speed Move")]
    [SerializeField] float mSpeed = 10f;
    [Header("Speed Jump")]
    [SerializeField] float mJump = 15f;
    [SerializeField] float mJumpLower;
    [Header("Speed Climb")]
    [SerializeField] float mClimb;

    Vector2 moveInput;
    Rigidbody2D mRigidbody;
    public static Animator mAnimation;
    static bool isLive;

    // check va cham voi wall
    BoxCollider2D mBoxCollider2D;
    static SpriteRenderer a_mSpr;
    
    // create bullets
    [Header("Gun and Bullet")]
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;
    [SerializeField] float timeFire;
    [SerializeField] float timeLive;
    float timeSpawn;


    private void Awake()
    {
        isLive = true;
    }
    void Start()
    {
        mRigidbody = GetComponent<Rigidbody2D>();
        mAnimation = GetComponent<Animator>();
        mBoxCollider2D = GetComponent<BoxCollider2D>();
        a_mSpr = GetComponent<SpriteRenderer>();
        
        timeSpawn = timeFire;
        //mAnimation.SetBool("isIdling", true);

    }

    void FixedUpdate()
    {
        Run();
        FlipPlayer();
        ClimbLadder();
        timeSpawn -= Time.deltaTime; 
    }

    public static void Idle()
    {
        //mAnimation.SetBool("isIdling", true);
        a_mSpr.color = Color.white;
        isLive = true;
    }
    void OnMove(InputValue mVector2)
    {
        
        moveInput = mVector2.Get<Vector2>();
    }

    void OnJump(InputValue mVector2)
    {
        //if (targetTime == 0)
        //{
        if (!mBoxCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
        else
        {
            if (mVector2.isPressed)
            {
                mRigidbody.velocity += new Vector2(0f, mJump);
            }
        }
        //}
    }
    void OnJumpLower(InputValue mVector2)
    {
        if (!mBoxCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
        else
        {
            if (mVector2.isPressed)
            {
                mRigidbody.velocity += new Vector2(0f, mJumpLower);
            }
        }
        //}
    }

    void OnFire(InputValue mVector2)
    {
        if (!isLive) { return; }
        if (mVector2.isPressed)
        {
            if (timeSpawn <= 0)
            {
                GameObject fireBullet = Instantiate(bullet, gun.position, gun.rotation);
                Destroy(fireBullet, timeLive);
                timeSpawn = timeFire;
            }
        }
    }
    void ClimbLadder()
    {
        if (mBoxCollider2D.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            mAnimation.SetBool("isClimbing", true);
            mRigidbody.velocity = new Vector2(mRigidbody.velocity.x, moveInput.y * mClimb);

            if (moveInput.y == 0)
            {
                mRigidbody.gravityScale = 0;
                mAnimation.SetBool("isClimbing", false);
            }
        }
        else
        {
            mAnimation.SetBool("isClimbing", false);
            mRigidbody.gravityScale = 8;
        }
    }
 
    void Run()
    {

        if ((!isLive)) 
        { return; }
        // Rigidbody2d.velocity.y: giúp character không "trôi nổi"(= 0) .Nếu sử dụng Vector2.x, giá trị trả về sẽ thuộc dạng 0.00001
        Vector2 mPlayerRun = new Vector2(moveInput.x * mSpeed, mRigidbody.velocity.y);
        mRigidbody.velocity = mPlayerRun;
        mAnimation.SetBool("isRunning",true);
        if ((moveInput.x == 0) ||(mBoxCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")) == false))
        {
            mAnimation.SetBool("isRunning", false);
           
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.gameObject.tag == "Hazard") || (collision.gameObject.tag =="Enemy"))
        {
            isLive = !isLive;
            Die();
        }

    }
    public void Die()
    {
        a_mSpr.color = Color.red;
        mAnimation.SetTrigger("isDying");
        FindObjectOfType<Session>().ProcessPlayerIsDying();
    }
    public void FlipPlayer()
    {
        // Epsilon: giá trị nhỏ nhất gần = 0
        // a + Mathf.Epsilon = a
        // Sign: trả về 1 nếu positive, ngược lại là -1
        if (Mathf.Abs(mRigidbody.velocity.x) > Mathf.Epsilon)
        {
            transform.localScale = new Vector2(Mathf.Sign(mRigidbody.velocity.x), 1f);
        }
    }
}
