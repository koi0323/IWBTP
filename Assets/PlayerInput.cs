using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private string moveAxisName = "Horizontal";
    private string fireButtonName = "Fire1";
    private string jumpButtonName = "Jump";

    public float move {get; private set;}
    public bool fire { get; private set;}
    public bool jump { get; private set;}
 

    // Update is called once per frame
    void Update()
    {
       
        move=Input.GetAxis(moveAxisName);
        fire = Input.GetButtonDown(fireButtonName);
        jump = Input.GetButtonDown(jumpButtonName);
    }
}
