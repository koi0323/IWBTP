using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 700f;
    public int jumpCount = 2;
    public bool isGrounded = false;
    public bool isDead = false;

    private Rigidbody2D playerRigidbody;
    private Animator animator;
    private PlayerInput playerInput;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody=GetComponent<Rigidbody2D>();
        playerInput=GetComponent<PlayerInput>();
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        //좌우움직임 구현
        if (playerInput.move < 0)
        {
            transform.Translate(new Vector3(-moveSpeed*Time.deltaTime,0,0));
        }
        if(playerInput.move > 0)
        {
            transform.Translate(new Vector3(moveSpeed*Time.deltaTime,0,0));
        }

        //점프구현
        if(playerInput.jump&&jumpCount>0)
        {
            jumpCount--;
            playerRigidbody.velocity = Vector2.zero;
            playerRigidbody.AddForce(new Vector2(0, jumpForce));

        }
        else if (Input.GetButtonUp("Jump") && playerRigidbody.velocity.y > 0)
        {
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
        }
    }
}
