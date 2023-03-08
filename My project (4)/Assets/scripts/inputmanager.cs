using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class inputmanager : MonoBehaviour
{   
    private Playerinput playerInput;
    private Playerinput.OnFootActions OnFoot;

    private playermotor motor;


    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new Playerinput();
        OnFoot = playerInput.OnFoot;
        motor = GetComponent<playermotor>();
        OnFoot.Jump.performed += ctx => motor.Jump();

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        motor.ProcessMove(OnFoot.Movement.ReadValue<Vector2>());
        
    }
    private void OnEnable()
    {
        OnFoot.Enable(); 
    }
    private void OnDisable()
    {
        OnFoot.Disable();
    }
}
