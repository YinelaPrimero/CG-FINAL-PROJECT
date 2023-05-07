using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public GameObject item;

    public int Id;
    public string tipo;
    public string descripcion;
    public bool vacio;

    public Sprite icon; 

    public Transform iconoSlotGameObject;

    [HideInInspector] // a pesar de ser una variable publica, no se verá en el inspector 
    public bool coleccionado; 

    public void UpdateSlot()
    {
        iconoSlotGameObject.GetComponent<Image>().sprite = icon;

    }


    void Start()
    {
        iconoSlotGameObject = transform.GetChild(0); //Coger el panel que esta sobre el slot para poner allí la iamgen y no directamente en el slot 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
