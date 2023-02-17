using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private BulletSpawner bulletSpawner;
    private PlayerMovement playerMovement;
    
    public Rigidbody2D bulletRigidody;
    public PlayerInput playerInput;
    public float bulletSpeed = 30f;
    //private Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        bulletSpawner = FindObjectOfType<BulletSpawner>();
        playerMovement = GetComponent<PlayerMovement>();
        bulletRigidody = GetComponent<Rigidbody2D>();
        playerInput = FindObjectOfType<PlayerInput>();
        if(!playerInput.isReverse)
        {
            bulletRigidody.velocity = new Vector2(bulletSpeed, bulletRigidody.velocity.y);
        }
        if (playerInput.isReverse)
        {
            bulletRigidody.velocity = new Vector2(-bulletSpeed, bulletRigidody.velocity.y);
        }
        //rigidbody=GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        // if(!GameManager.instance.isGameOver)
        //{
        
        //}
    }
    
    public void Destroi()
    {
        bulletSpawner.onBullet--;
        if (bulletSpawner.onBullet < 0) { bulletSpawner.onBullet = 0; }
        Destroy(gameObject);
    }
}
