using System.Diagnostics;
using System.Net.Http.Headers;
using System.Collections.ObjectModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float VidaPersonaje=100f;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider Colli){
        if(Colli.CompareTag("ArmaEnemigo")){
            RecibirDaño();
        }
    }

    public void RecibirDaño(){
        VidaPersonaje -= 5f;
        print("Daño recibido, vida actual: "+VidaPersonaje);
    }
}
