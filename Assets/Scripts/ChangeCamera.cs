using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{

    private Camera mainCamera;
    public Transform cameraPosition;
    private void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") { 
            
        }
    }





}
