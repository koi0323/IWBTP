using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public string horizontal = "Horizontal";
    
    public float move { get; private set; }
    public bool isJump { get; private set; }
    public bool fire { get; private set; }
    public float jump = 1f;
    public Animator playerAnimator;
    public bool isReverse = false;

// Start is called before the first frame update
void Start()
    {
        playerAnimator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxisRaw(horizontal);//-1 or +1
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            isReverse = true;
            
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            isReverse = false;
            
        }
        fire = Input.GetKeyDown(KeyCode.X);
        isJump = Input.GetKeyDown(KeyCode.Z);//มกวม
        if (isJump)
        {
            jump = 1f;
        }
        else jump = 0f;
    }
}
