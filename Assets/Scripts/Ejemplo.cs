using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejemplo : MonoBehaviour
{
    public static Ejemplo instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance= this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        //if (Input.GetKeyDown(Keycode.L)
        
    }
}
