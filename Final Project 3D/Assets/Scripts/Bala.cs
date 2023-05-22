using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{   
    public float velocidad = 20f;
    public Rigidbody rb;
    public int daño = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * velocidad;
    }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.CompareTag("Enemigo"))
    //     {
    //         Enemigo enemigo = collision.GetComponent<Enemigo>();

    //         if (enemigo != null)
    //         {
    //             enemigo.tomarDaño(daño);
    //         }

    //         Destroy(gameObject);
    //     }
    // }
}
