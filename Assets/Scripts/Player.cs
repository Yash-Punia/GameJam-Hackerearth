using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController controller;
    camera cam;
    [SerializeField] float speed = 6f;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<camera>();   
    }

    // Update is called once per frame
    void Update()
    {
        HandleKeyboardInput();
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 20f;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 6f;
        }
        
    }

    

    private void HandleKeyboardInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = transform.right * horizontal + transform.forward * vertical;
        if (direction.magnitude >= 0.1f)
        {
            controller.Move(direction * speed * Time.deltaTime);
        }
    }
}
