using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCameraWall : BulletDestroyer, TranslateCamera
{
    MoveCamera moveCamera;
    public void CameraMove(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("플레이어 닿음");
            moveCamera = GetComponentInParent<MoveCamera>();
            moveCamera.CameraMove(-moveCamera.cameraWidth, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        BulletDest(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CameraMove(collision);
    }

}
