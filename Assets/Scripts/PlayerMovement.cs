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
            transform.localScale = new Vector3(-size,size,size);//�ݴ���� ���Բ�
            playerAnimator.SetFloat("Move", playerInput.move);//�ִϸ��̼� ����
            
        }
        if (!playerInput.isReverse)
        {
            transform.localScale = new Vector3(size,size,size);
            playerAnimator.SetFloat("Move", -playerInput.move);//�ִϸ��̼� ���� ������ ������ ������ ������ �ȴ� �ִϸ��̼��� �����Բ� �ϱ� ����
            
        }
    }
    void Jump() {

        if (playerInput.isJump&&jumpCount>0)
        {
            if (jumpCount == 2)
            {
                playerRigidbody.velocity = Vector2.zero;//������ �ӵ� ���������� 0

                playerRigidbody.AddForce(new Vector2(0, jumpForce));
                Debug.Log("System : ù ����");
                Debug.Log("System : ù ���� �� : "+jumpForce);
                jumpCount--;
            }
            else if (jumpCount == 1) { //2�� �����ÿ��� ������ ����
                playerRigidbody.velocity = Vector2.zero;//������ �ӵ� ���������� 0

                playerRigidbody.AddForce(new Vector2(0, jumpForce*0.8f));
                Debug.Log("System : 2�� ����");
                Debug.Log("System : 2�� ���� �� : "+ jumpForce * 0.8f);
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
        //� �ݶ��̴��� �������, �浹 ǥ���� ������ ���� ���� ��
        if (collision.contacts[0].normal.y > SteppedVectorY)
        {
            
            isGrounded = true;
            jumpCount = 2;

        }
        //������ ���� �浹���� �� �ӵ��� ��� ������ ���ϰ� ��
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


        // �ٴڿ� ������� �����ϴ� ó��
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
        // �ٴڿ��� ������� �����ϴ� ó��
    }

}
