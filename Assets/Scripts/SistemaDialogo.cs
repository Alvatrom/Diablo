using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaDialogo : MonoBehaviour
{
    //patron singleton:
         //1. Solo existe una unica instancia de SistemaDialogo
         //2. Es accesible desde Cualquier Punto del programa
         //3.

    //cuando es estatica;esa variable pertenece a la clase(no a las instamcias de la clase)(un unico trono)
    public static SistemaDialogo sitema;

    //Awake se ejecuta antes del start() independientemente de que 
    //el gameobject este activa o no
    void Awake()
    {
        //Si el trono esta libre...
        if (sitema == null)
        {
            //me hago con el trono, y entonces SistemaDialogo SOY YO (this).
            sitema = this;
        }
        else
        {
            //esta ocupado pues me suicido
          Destroy(this.gameObject);

        }
    }

    public void IniciarDialogo(DialogoSO dialogo)
    {

    }

    
    void Update()
    {
        
    }
}
