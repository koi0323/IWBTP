using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private float speedWeight;
    private float yPos;
    public Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        yPos = transform.position.y;
        speedWeight = (3.5f - yPos)/3f;
        if ( yPos>3.5f )
        {
            rigidbody.AddForce(new Vector2(0,speedWeight));
        }
        if(yPos<3.5f)
        {
            rigidbody.AddForce(new Vector2(0, speedWeight));
        }

    }
}
