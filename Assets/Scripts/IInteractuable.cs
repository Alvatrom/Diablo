using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//interfaz es una serie de metodos que se han de impplementar
//en aquellas identidades que , en este caso, sean interactuables
public interface IInteractuable
{
    public void Interactuar(Transform interactor);
}
