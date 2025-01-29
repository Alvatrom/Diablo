using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (menuName = "Misión")]
public class MisionSO : ScriptableObject
{
    public string ordenInicial; //mensaje inicial
    public string ordenFinal; //Mensaje victoria
    public bool tieneRepeticion;
    public int totalRepeticiones; //veces que teng que repetir ese paso
    public int indiceMision; //indice unico que representa a cada mision


    [NonSerialized] //PARA QUE EL CAMBIO PUEDA RESETEAR ENTRE PARTIDAS
    public int repeticionActual = 0; // (3/8)..... el avance de repeticion
    
}
