using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour,IInteractuable
{
    [SerializeField] 
    private EventManagerSO eventManager;

    [SerializeField]
    private MisionSO miMision;

    [SerializeField] 
    private DialogoSO dialogo1;

    [SerializeField] 
    private DialogoSO dialogo2;


    [SerializeField] 
    private Transform cameraPoint; //punto en el que se pondra CameraNPC

    [SerializeField] 
    private float duracionRotacion = 0.5f;




    private DialogoSO dialogoActual;

    [SerializeField] 
    private DialogoSO miDialogo;


    private void Awake()
    {
        dialogoActual = dialogo1;
    }

    private void OnEnable()
    {
        eventManager.OnTerminarMision += CambiarDialogo;
    }


    private void OnDisable()
    {
        eventManager.OnTerminarMision -= CambiarDialogo;
    }

    private void CambiarDialogo(MisionSO misionTerminada)
    {
        if(miMision == misionTerminada)
        {
            dialogoActual = dialogo2;
        }
    }
    public void Interactuar(Transform interactuador)
    {
        transform.DOLookAt(interactuador.position, duracionRotacion, AxisConstraint.Y).OnComplete(IniciarDialogo);
    }

    private void IniciarDialogo()
    {
        SistemaDialogo.sD.IniciarDialogo(dialogoActual, cameraPoint);
    }
}
