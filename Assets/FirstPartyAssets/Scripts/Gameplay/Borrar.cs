using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borrar : MonoBehaviour
{
    public float speed;
    [SerializeField] Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {

        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            MovePlayerRelativeToCamera();
            //rb.MovePosition(rb.position + moveInput * speed * Time.fixedDeltaTime);
        }
    }

    void MovePlayerRelativeToCamera()
    {
        //Importar los datos de los vectores
        float playermovX = Input.GetAxis("Horizontal");
        float playermovZ = Input.GetAxis("Vertical");

        //Traer las coordenadas de la camara
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        //El valor de y de la camara no influye en el movimiento del personaje
        forward.y = 0;
        right.y = 0;

        //Normalizar los valores
        forward = forward.normalized;
        right = right.normalized;

        //Multiplicar los valores de los vectores del jugador y la camara
        Vector3 forwardRelativeVerticalInput = playermovZ * forward;
        Vector3 rightRelativeHorizontalInput = playermovX * right;

        //Crear una camara relativa la movimiento
        Vector3 cameraRelativeMovement = forwardRelativeVerticalInput + rightRelativeHorizontalInput;

        float targetAngle = Mathf.Atan2(cameraRelativeMovement.x, cameraRelativeMovement.z) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

        transform.Translate(cameraRelativeMovement * speed * Time.deltaTime, Space.World);
    }
}
