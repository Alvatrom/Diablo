using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaGuardado : MonoBehaviour
{

    [SerializeField] private GameManagerSO gM;

    //meter botones de guardado
    public void GuardarPartida()
    {
        gM.lifes = 100;
        gM.ultimaPosicion = new Vector3(50, 90, 180);
        SaveSystem.Save(gM);
    }
    //boton de cargado
    
    /*public PersitentData CargarPartida()
    {
        PersitentData dataToLoad = SaveSystem.Load();
        return dataToLoad;
    }*/
}
