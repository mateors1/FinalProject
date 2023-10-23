using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePLayer : MonoBehaviour
{
    private InputAction moveAction;
    private Rigidbody rb;
    [SerializeField] GameObject Camera;
    [SerializeField] float speed, sensitivity;
    Vector2 move, look;
    void Start()
    {
        moveAction = new InputAction("Move");
        moveAction.Enable();
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        MimiMovement();
    }



 



    void MimiMovement()
    {
        Vector2 movement = moveAction.ReadValue<Vector2>();

        rb.AddForce(movement += movement * speed * Time.fixedDeltaTime, ForceMode.Impulse);
    }
}
