using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private DialogoSO dialogoActual;

    [SerializeField]
    private DialogoSO miDialogo;


    [SerializeField] 
    private Transform cameraPoint; //punto en el que se pondra CameraNPC

    [SerializeField] 
    private float duracionRotacion = 0.5f;

    [SerializeField]
    private Outline outline;
    [SerializeField] private Texture2D iconoPorDefecto;
    [SerializeField] private Texture2D iconoInteraccion;

    //[SerializeField] private AudioSource audioNPC;


    //[SerializeField] private Player player;



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
        //poco a poco voy rotandome hacia el interactuador y cuando termine de rotarme se inicia
        AudioManager.instance.PlaySFX("NPC");
        transform.DOLookAt(interactuador.position, duracionRotacion, AxisConstraint.Y).OnComplete(IniciarDialogo);
    }

    private void IniciarDialogo()
    {
        SistemaDialogo.sistema.IniciarDialogo(dialogoActual, cameraPoint);
    }

    private void OnMouseEnter()
    {
        outline.enabled = true;
    }
    private void OnMouseExit()
    {
        outline.enabled = false;
    }
}
