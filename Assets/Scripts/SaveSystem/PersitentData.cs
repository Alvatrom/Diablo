using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable] // para que se pueda guardar la informacion en el scrpt
public class PersitentData : MonoBehaviour
{

    private int lifes = 90;

    private float xPosition, yPosition, zPosition;


    public PersitentData(int vidasAGuardar, Vector3 posicionAGuardar)
    {
        lifes = vidasAGuardar;
        xPosition = posicionAGuardar.x;
        yPosition = posicionAGuardar.y;
        zPosition = posicionAGuardar.z;

    }
}
