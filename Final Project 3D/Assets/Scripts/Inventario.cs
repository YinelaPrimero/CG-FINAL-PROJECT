using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    //Activacion del inventario
    private bool inventarioAcvtivado;

    //Hace referencia al panel del inventario 
    public GameObject inventario;

    //Se guarda la cantidad de slots que se tiene en el inventario 
    private int slots;

    private int disponibilidadSlots; 

    private GameObject[] slot;

    public GameObject slotHolder;
    
    void Start()
    {
        //Slots son hijos de slotHolder, por lo tanto, se obtiene su cantidad para conocer la cantidad de espacios que tiene el inventario  
        slots = slotHolder.transform.childCount; 

        //Se incializa el arreglo de los slots con la cantidad de slots correspondiente 
        slot = new GameObject[slots];

        for(int i = 0; i< slots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;
            
            if(slot[i].GetComponent<Slot>().item == null)
            {
                slot[i].GetComponent<Slot>().vacio = true;  //Revisar este paso por si aparecen los obejtos despues de perder 
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            //Dar el valor contario al inventario (si es true ahora es false y al reves )
           inventarioAcvtivado =! inventarioAcvtivado; 

            if(inventarioAcvtivado)
            {
                inventario.SetActive(true);
            }
            else
            {
                inventario.SetActive(false);
            }

        }
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Item")
        {
            GameObject objetoColeccionado = col.gameObject;
            Item item = objetoColeccionado.GetComponent<Item>();

            AddItem(objetoColeccionado, item.Id, item.tipo, item.descripcion, item.icon);
        }

    }

    public void AddItem(GameObject itemObject, int itemId, string itemTipo, string itemDescription, Sprite itemIcon)
    {
        for (int i = 0 ; i< slots; i++)
        {
            if(slot[i].GetComponent<Slot>().vacio)
            {
                itemObject.GetComponent<Item>().coleccionado = true;
                slot[i].GetComponent<Slot>().item = itemObject;
                slot[i].GetComponent<Slot>().Id = itemId;
                slot[i].GetComponent<Slot>().tipo = itemTipo;
                slot[i].GetComponent<Slot>().descripcion = itemDescription;
                slot[i].GetComponent<Slot>().icon = itemIcon;

                itemObject.transform.parent = slot[i].transform;
                itemObject.SetActive(false);

                slot[i].GetComponent<Slot>().UpdateSlot();

                slot[i].GetComponent<Slot>().vacio = false;

                return; //Romper el ciclo para que no se añada el objeto coleccioando a todo el inventario  
            }

            

        }
    }




}
