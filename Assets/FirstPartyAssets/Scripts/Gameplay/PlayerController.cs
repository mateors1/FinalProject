using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    [SerializeField] Rigidbody rb;
    private Animator animator;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {

        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            animator.SetBool("IsWalking", true);
            MovePlayerRelativeToCamera();
            //rb.MovePosition(rb.position + moveInput * speed * Time.fixedDeltaTime);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
        if (rb.velocity.magnitude > 0.1f)
        {
            audioSource.Play();
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

        transform.Translate(cameraRelativeMovement * speed * Time.fixedDeltaTime, Space.World);
    }
}
