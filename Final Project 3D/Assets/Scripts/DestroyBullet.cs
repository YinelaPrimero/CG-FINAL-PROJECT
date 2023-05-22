using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    public GameObject obj;

    private void Start()
    {
        DestroySeconds();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void DestroySeconds()
    {
        Destroy(obj, 2f);
    }
}
