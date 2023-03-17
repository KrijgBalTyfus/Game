using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playervelocity;
    private bool isGrounded;
    public float speed = 5f;
    public float gravity = -22.81f;
    public float jumpHeight = 100f;



    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
        
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playervelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playervelocity.y < 0)
            playervelocity.y = -2f;
        controller.Move(playervelocity * Time.deltaTime);
        Debug.Log(playervelocity.y); 
    }
    public void Jump()
    {
        if (isGrounded)
        { 
            playervelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }

    }
}
 