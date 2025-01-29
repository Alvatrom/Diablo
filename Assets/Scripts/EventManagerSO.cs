using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Event Manager")]
public class EventManagerSO : ScriptableObject
{
    //creo un evento
    public event Action<MisionSO> OnNuevaMision;
    public event Action<MisionSO> OnActualizarMision;
    public event Action<MisionSO> OnTerminarMision;

    public void NuevaMision(MisionSO mision)
    {
        // Lanzar/disparar el evento/notificacion con parametros(informacion adicional)

        //?. -> Invocacion SEGURA
        OnNuevaMision?.Invoke(mision);
    }

    internal void ActualizarMision(MisionSO mision)
    {
        OnActualizarMision?.Invoke(mision);
    }

    public void TerminarMision(MisionSO mision)
    {
        OnTerminarMision?.Invoke(mision);
    }
}
