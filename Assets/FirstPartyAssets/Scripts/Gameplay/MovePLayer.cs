using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePLayer : MonoBehaviour
{
    [SerializeField] InputActionAsset playerControls;
    private InputAction moveAction;
    private Rigidbody rb;
    [SerializeField] GameObject Camera;
    [SerializeField] float speed, sensitivity;
    Vector2 move, look;
    void Start()
    {
        moveAction = playerControls.FindAction("Move");
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

        Vector3 mimiMoves = new Vector3(movement.x, 0, movement.y);

        rb.AddForce(mimiMoves += mimiMoves * speed * Time.fixedDeltaTime, ForceMode.Impulse);
    }
}
