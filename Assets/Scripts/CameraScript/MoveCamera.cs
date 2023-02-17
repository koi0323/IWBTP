using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    public float cameraWidth = 32f;
    public float cameraheight = 18f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void CameraMove(float x,float y)
    {
        transform.position = new Vector3(transform.position.x+x, transform.position.y+y,-0.79f);


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
