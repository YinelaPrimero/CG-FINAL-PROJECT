using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator animator;
    public Quaternion angulo;
    public float grado;

    public GameObject target;
    public bool atacando;

    public GameObject arma;
    public bool stuneado;

    public RangoEnemigo rango;
    public float speed;

    public NavMeshAgent agente;
    public float distanciaAtaque;
    public float radioVision;

    private bool isMovingToTarget;

    void Start()
    {
        animator = GetComponent<Animator>();
        agente = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        ComportamientoEnemigo();
    }

    public void ComportamientoEnemigo()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > radioVision)
        {
            agente.enabled = false;
            animator.SetBool("Run", false);

            cronometro += Time.deltaTime;

            if (cronometro >= 4)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }

            switch (rutina)
            {
                case 0:
                    animator.SetBool("Walk", false);
                    break;
                case 1:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    rutina++;
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * speed * Time.deltaTime);
                    animator.SetBool("Walk", true);
                    break;
            }
        }
        else
        {
            agente.enabled = true;
            agente.SetDestination(target.transform.position);

            if (Vector3.Distance(transform.position, target.transform.position) > distanciaAtaque && !atacando)
            {
                animator.SetBool("Walk", false);
                animator.SetBool("Run", true);
                isMovingToTarget = true;
            }
            else
            {
                if (!atacando)
                {
                    animator.SetBool("Walk", false);
                    animator.SetBool("Run", false);
                    isMovingToTarget = false;
                }
            }
        }

        if (!atacando && !isMovingToTarget)
        {
            agente.enabled = false;
        }
    }

    public void FinalAni()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > distanciaAtaque + 0.2f)
        {
            animator.SetBool("Atack", false);
        }

        atacando = false;
        stuneado = false;
        rango.GetComponent<CapsuleCollider>().enabled = true;
    }

    public void ColliderWeaponTrue()
    {
        arma.GetComponent<BoxCollider>().enabled = true;
    }

    public void ColliderWeaponFalse()
    {
        arma.GetComponent<BoxCollider>().enabled = false;
    }
}
