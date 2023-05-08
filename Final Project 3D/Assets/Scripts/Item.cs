using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int Id;
    public string tipo;
    public string descripcion;
    public Sprite icon; 

    [HideInInspector] // a pesar de ser una variable publica, no se verá en el inspector 
    public bool coleccionado; 

    [HideInInspector]
    public bool equipado;

    [HideInInspector]
    public GameObject controladorArmas;

    [HideInInspector]
    public GameObject arma;

    private int cantidadArmas;

  
    public GameObject Personaje;
    public Animator animPersonaje;

    
    void Start()
    {
        Personaje = GameObject.FindWithTag("Player");
        animPersonaje = Personaje.GetComponent<Animator>();

        controladorArmas = GameObject.FindWithTag("ControladorArmas");
        
        int cantidadArmas = controladorArmas.transform.childCount;
        Debug.Log("Cogi la cantidad de armas" + cantidadArmas.ToString());
        
        for(int i = 0; i<cantidadArmas; i++)
        {
            if(controladorArmas.transform.GetChild(i).gameObject.GetComponent<Item>().Id==Id)
            {
                arma = controladorArmas.transform.GetChild(i).gameObject;
                Debug.Log("Cogi la referencia de arma");
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        if(equipado)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                equipado = false;
            }
            if(equipado == false)
            {
                gameObject.SetActive(false);
            }

        }
        
    }

    public void UsoItem()
    {
        if(tipo == "Arma")
        {
            arma.SetActive(true);
            arma.GetComponent<Item>().equipado = true;
            animPersonaje.SetBool("Armado", true);
        }

    }
}
