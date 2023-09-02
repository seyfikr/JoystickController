using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Animator anim;
    public float moveSpeed = 5.0f;
    private Rigidbody rb;
    private JoystickController joystickController;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameObject gameManager = GameObject.Find("joystick");
        joystickController = gameManager.GetComponent<JoystickController>();
        anim=GetComponent<Animator>();
    }

    private void Update()
    {
        
        float horizontalInput = joystickController.inputHorizontal();
        float verticalInput = joystickController.inputVertical();
        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);
        movement.Normalize(); 
        rb.velocity = movement * moveSpeed;

        

        if (joystickController.posInput.y > 0.1f)
        {
            anim.SetBool("ForwarRun", true);
            anim.SetBool("ForwardBack", false);
            
            anim.SetBool("Ýdle", false);
        }
        if (joystickController.posInput.y < 0.1)
        {
            anim.SetBool("ForwardBack", true);
            anim.SetBool("ForwarRun", false);
            anim.SetBool("Ýdle", false);
        }
        if (joystickController.posInput.y ==0)
        {
            anim.SetBool("Ýdle", true);
            anim.SetBool("ForwardBack", false);
            anim.SetBool("ForwarRun", false);
        }



    }
}
