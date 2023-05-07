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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
