using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private DialogoSO miDialogo;
    [SerializeField] private float duracionRotacion;


    [SerializeField] private Transform cameraPoint; //punto en el que se pondra CameraNPC

    public void Interactuar(Transform interactuador)
    {
        transform.DOLookAt(interactuador.position, duracionRotacion, AxisConstraint.Y).OnComplete(IniciarInteracion);
    }


    private void IniciarInteracion()
    {
        //SistemaDialogo.sistema.IniciarDialogo(miDialogo, cameraPoint);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
