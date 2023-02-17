using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   public float speed=12f;
    public float jumpForce = 700f;
    public bool isGrounded = true;
    public float size = 4f;
    public PlayerInput playerInput;
    public Rigidbody2D playerRigidbody;
    public Animator playerAnimator;
    public float SteppedVectorY=0.2f;
    public int jumpCount = 2;
    
    
    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();


        Jump();

        if (playerInput.fire)
        {
            
            
        }
        playerAnimator.SetBool("isGround", isGrounded);
        
    }
     void Move()
    {
        Vector2 newVelocity = new Vector2(playerInput.move * speed, playerRigidbody.velocity.y);
        playerRigidbody.velocity = newVelocity;


        if (playerInput.isReverse)
        {
            transform.localScale = new Vector3(-size,size,size);//반대방향 보게끔
            playerAnimator.SetFloat("Move", playerInput.move);//애니메이션 제어
            
        }
        if (!playerInput.isReverse)
        {
            transform.localScale = new Vector3(size,size,size);
            playerAnimator.SetFloat("Move", -playerInput.move);//애니메이션 제어 음수인 이유는 좌측을 보더라도 걷는 애니메이션이 나오게끔 하기 위해
            
        }
    }
    void Jump() {

        if (playerInput.isJump&&jumpCount>0)
        {
            if (jumpCount == 2)
            {
                playerRigidbody.velocity = Vector2.zero;//점프시 속도 순간적으로 0

                playerRigidbody.AddForce(new Vector2(0, jumpForce));
                Debug.Log("System : 첫 점프");
                Debug.Log("System : 첫 점프 힘 : "+jumpForce);
                jumpCount--;
            }
            else if (jumpCount == 1) { //2단 점프시에는 점프힘 절반
                playerRigidbody.velocity = Vector2.zero;//점프시 속도 순간적으로 0

                playerRigidbody.AddForce(new Vector2(0, jumpForce*0.8f));
                Debug.Log("System : 2단 점프");
                Debug.Log("System : 2단 점프 힘 : "+ jumpForce * 0.8f);
                jumpCount--;
            }
        }
        if (playerRigidbody.velocity.y > 0)
        {
            playerAnimator.SetFloat("isUp", 0);
        }
        else { playerAnimator.SetFloat("isUp", 1); }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.contacts[0].normal);
        //어떤 콜라이더와 닿았으며, 충돌 표면이 위쪽을 보고 있을 때
        if (collision.contacts[0].normal.y > SteppedVectorY)
        {
            
            isGrounded = true;
            jumpCount = 2;

        }
        //세로의 벽과 충돌했을 때 속도를 계속 가지지 못하게 함
        /*if (collision.contacts[0].normal == new Vector2(1.0f, 0.0f) || collision.contacts[0].normal == new Vector2(-1.0f, 0.0f))
        {
            if (collision.contacts[0].normal == new Vector2(1.0f, 0.0f)) {
                Debug.Log("Vector2 (1,0)");
                if (playerRigidbody.velocity.x < 0) {
                    
                    playerRigidbody.velocity = new Vector2(0, playerRigidbody.velocity.y);
                }

            }
            if (collision.contacts[0].normal == new Vector2(-1.0f, 0.0f))
            {
                Debug.Log("Vector2 (-1,0)");
                if (playerRigidbody.velocity.x > 0)
                {
                    playerRigidbody.velocity = new Vector2(0, playerRigidbody.velocity.y);
                }

            }
            
            playerRigidbody.velocity = new Vector2(0, playerRigidbody.velocity.y);
            Debug.Log(collision.contacts[0].normal);
            speed = 0f;
        }*/


        // 바닥에 닿았음을 감지하는 처리
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
        // 바닥에서 벗어났음을 감지하는 처리
    }

}
