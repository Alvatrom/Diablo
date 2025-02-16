using Microsoft.Unity.VisualStudio.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDanhable
{
    [SerializeField]
    private float vidasIniciales;


    /*[SerializeField]
    private LocalCanvas localCanvas;*/

    /*[SerializeField]
    private Image healthBar;*/ ////////////////////mirar como hacer  esto


    [SerializeField]
    private Outline outline;
    [SerializeField] private Texture2D iconoPorDefecto;
    [SerializeField] private Texture2D iconoInteraccion;

    /*[SerializeField]
    private Collider coll;*///////////////////////////////////////////////////////////////////


    private NavMeshAgent agent; //porque lo necesita aqui tambien?

    private SistemaCombate combate;
    private SistemaPatrulla patrulla;
    private EnemigoAnimaciones visualSystem;

    [SerializeField] private Transform target;//porque el no tiene este codigo?
    
    [SerializeField] private Transform barraVida;

    

    public NavMeshAgent Agent { get => agent; set => agent = value; }
    public SistemaCombate Combate { get => combate; set => combate = value; }
    public SistemaPatrulla Patrulla { get => patrulla; set => patrulla = value; }
    public EnemigoAnimaciones VisualSystem { get => visualSystem; set => visualSystem = value; }


    public Transform Target { get => target; set => target = value; }


    private float vidasActuales;
    private bool muerto;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateUpAxis = false;//evita que el eje Y del agente sea actualizado automáticamente //////se supone
        vidasActuales = vidasIniciales;

    }


    void Start()
    {
        //Empieza el juego y activamos la patrulla
        patrulla.enabled = true;
    }


    public void ActivarCombate(Transform target)
    {
        patrulla.enabled = false;
        this.Target = target;
        combate.enabled = true;
    }

    public void ActivarPatrulla()
    {
        //Deshbilitar combate
        combate.enabled = false;
        //habilitar patrulla
        patrulla.enabled = true;
    }

    public void RecibirDanho(float danho)
    {
        throw new NotImplementedException();
    }

    private void Muerte()
    {

        //Destroy(localCanvas.gameObject);
        //Destroy(coll);
        Destroy(combate);
        Destroy(patrulla.gameObject);
        Destroy(gameObject, 5);
        visualSystem.EjecutarAnimacionMuerte();
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
