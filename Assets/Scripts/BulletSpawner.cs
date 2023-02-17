using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;//ÃÑ¾Ë¿øº»ÇÁ¸®ÆÕ
    public int bulletCount = 5;//ÃÑ¾Ë°³¼ö
    public Transform FirePos;
    public PlayerInput playerInput;
    private GameObject bullet;
    
    


    public int onBullet = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerInput = FindObjectOfType<PlayerInput>();
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(GameManager.instance.isGameOver)
        {
            return;
        }*/
        if (onBullet < bulletCount && playerInput.fire)
        {
            Debug.Log("¹ß»çÅ° ´©¸§");
            bullet = Instantiate(bulletPrefab,FirePos.transform.position,Quaternion.identity);
            onBullet++;
        }
       
    }
    
    
}
