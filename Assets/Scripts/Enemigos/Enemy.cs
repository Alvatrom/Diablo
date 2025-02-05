using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
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

    private Transform target;//porque el no tiene este codigo?

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


    public void ActivarCombate(Transform transform)
    {
        patrulla.enabled = false;
        combate.enabled = true;
        this.Target = target;
    }

    public void ActivarPatrulla()
    {
        //Deshbilitar combate
        combate.enabled = false;
        //habilitar patrulla
        patrulla.enabled = true;
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
