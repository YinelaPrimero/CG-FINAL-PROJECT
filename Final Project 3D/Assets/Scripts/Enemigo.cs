using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator Animator;
    public Quaternion angulo;
    public float grado;

    public GameObject Target;
    public bool Atacando;


    void Start()
    {
        Animator = GetComponent<Animator>();
       
    }

    void Update()
    {
        ComportamientoEnemigo();
    }

    public void ComportamientoEnemigo()
    {
        if(Vector3.Distance(transform.position,Target.transform.position)>5){
            Animator.SetBool("Run",false); 
        
        cronometro += 1 * Time.deltaTime;

        if(cronometro >=4){
            rutina = Random.Range(0,2);
            cronometro = 0;
        }

        switch (rutina)
        {
            case 0:
                Animator.SetBool("Walk", false);
                break;
            case 1: 
                grado = Random.Range(0,360);
                angulo = Quaternion.Euler(0, grado, 0);
                rutina++;
                break;
            case 2:
                transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                transform.Translate(Vector3.forward* 1* Time.deltaTime);
                Animator.SetBool("Walk",true);
                break;
            

         
        }
    }
    else
     { 
        if(Vector3.Distance(transform.position, Target.transform.position)> 1 && !Atacando){

        
     var LookPos = Target.transform.position - transform.position;
     LookPos.y = 0;
     var rotation = Quaternion.LookRotation(LookPos);
     transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation , 3);
     Animator.SetBool("Walk",false);

     Animator.SetBool("Run",true);
     transform.Translate(Vector3.forward* 1.1f*Time.deltaTime);

     Animator.SetBool("Atack",false);
        }
        else{
            Animator.SetBool("Walk",false);
            Animator.SetBool("Run",false);

            Animator.SetBool("Atack", true);
            Atacando = true;
        }
    }
    }

    public void FinalAni(){
        Animator.SetBool("Atack",false);
        Atacando = false;
    }
}
