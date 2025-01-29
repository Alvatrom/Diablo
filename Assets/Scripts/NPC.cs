using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour,IInteractuable
{
    [SerializeField] private DialogoSO miDialogo;
    [SerializeField] private float duracionRotacion;


    [SerializeField] private EventManagerSO eventManager;

    [SerializeField]


    private DialogoSO dialogoActual;




    [SerializeField] private Transform cameraPoint; //punto en el que se pondra CameraNPC

    public void Interactuar(Transform interactuador)
    {
        transform.DOLookAt(interactuador.position, duracionRotacion, AxisConstraint.Y).OnComplete(IniciarInteracion);
    }

    private void CambiarDialogo(MisionSO misionTerminada)
    {
        if(misionTerminada == misionTerminada)
        {
            //dialogoActual = dialogo2;
        }
    }

    public void Interactuar()
    {
        throw new NotImplementedException();
    }

    private void IniciarInteracion()
    {
        //SistemaDialogo.sistema.IniciarDialogo(miDialogo, cameraPoint);
    }
    private void Awake()
    {
        //dialogoActual = dialogo1;
    }
    private void OnDisable()
    {
        eventManager.OnTerminarMision -= CambiarDialogo;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
