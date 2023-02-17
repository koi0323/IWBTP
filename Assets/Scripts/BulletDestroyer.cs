using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        BulletDest(collision);
    }

    public virtual void BulletDest(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Bullet bullet = collision.GetComponent<Bullet>();

            if (bullet != null)
            {
                Debug.Log("ÃÑ¾Ë ´ê¾ÒÀ½");
                bullet.Destroi();
            }

        }
    }
}
