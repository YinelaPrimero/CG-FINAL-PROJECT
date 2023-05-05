using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov3Person : MonoBehaviour
{
    private CharacterController controller;

    public static float veloMovi = 2f;
    public float veloRota = 10f;
    public static float X, Z;
    
    [SerializeField] private Camera followCamera;

    private Vector3 veloJugador;
    public Transform checkPiso;
    public float distanciaPiso = 0.4f;
    public LayerMask piso;
    public float gravedad = -9.81f;
    public float salto = 1f;

    public Animator animator;

    bool enPiso;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Movimiento();
      
    }

    public void Movimiento()
    {
        enPiso = Physics.CheckSphere(checkPiso.position, distanciaPiso, piso);

        if (enPiso && veloJugador.y < 0)
        {
            veloJugador.y = -2f;

        }

        X = Input.GetAxis("Horizontal");
        Z = Input.GetAxis("Vertical");

        Vector3 moveInput = Quaternion.Euler(0, followCamera.transform.eulerAngles.y, 0) * new Vector3(X, 0, Z);

        Vector3 moveDirection = moveInput.normalized;

        controller.Move(moveDirection * veloMovi * Time.deltaTime);

        if(moveDirection != Vector3.zero)
        {
            Quaternion rotacion = Quaternion.LookRotation(moveDirection, Vector3.up);

            transform.rotation = Quaternion.Slerp(transform.rotation, rotacion, veloRota * Time.deltaTime);


         //   AniJugador.Walk();
        }

        if(Input.GetButtonDown("Jump") && enPiso)
        {
            veloJugador.y = Mathf.Sqrt(salto * -2f * gravedad);
        }

        veloJugador.y += gravedad * Time.deltaTime;
        controller.Move(veloJugador * Time.deltaTime);

    }
}