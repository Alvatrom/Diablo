using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaCombate : MonoBehaviour, IDanhable
{
    [SerializeField] private Enemy main;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator anim;

    //probar
    [Header("Sistema de ataque")]
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float radioAtaque = 1;
    [SerializeField] private LayerMask queEsDanhable;
    [SerializeField] private Player player;
    private bool ventanaAbierta;
    private bool puedoDanhar = true;
    [SerializeField] private float danhoEnemigo = 25, danhoRecibido;



    [SerializeField] float velocidadCombate = 8f, distanciaAtaque, danhoAtaque;


    private void Awake()
    {
        main.Combate = this;
    }

    private void OnEnable()//el combate ha sido habilitado
    {
        agent.speed = velocidadCombate;
        agent.stoppingDistance = distanciaAtaque;

    }
    private void Update()
    {

        if (main.Target != null && agent.CalculatePath(main.Target.position, new NavMeshPath()))
        {
            // Procuramos que siempre estemos enfocando al player
            EnfocarObjetivo();
            // Perseguiremos al objetivo
            agent.SetDestination(main.Target.position);

            // Cuando tenga al objetivo a distancia de ataque...
            if (!agent.pathPending && agent.remainingDistance <= distanciaAtaque)
            {
                //Debug.Log("Distancia restante: " + agent.remainingDistance);

                // Solo activa si no está ya atacando
                if (!anim.GetBool("attacking"))
                {
                    Debug.Log("Distancia restante: " + agent.remainingDistance);
                    anim.SetBool("attacking", true);
                }
            }
            else if (!agent.pathPending && agent.remainingDistance > distanciaAtaque)
            {
                // Desactivar el ataque si el enemigo está fuera de la distancia de ataque
                anim.SetBool("attacking", false);
                agent.isStopped = false;
            }
        }
        else
        {
            // Desactivar el ataque si no hay objetivo o no es alcanzable
            anim.SetBool("attacking", false);
            agent.isStopped = false;
            main.ActivarPatrulla();
        }
    }

    private void EnfocarObjetivo()
    {
        //1. calculo ña direccion al objetivo
        Vector3 direccionATarget =(main.Target.transform.position -  this.transform.position).normalized;
        direccionATarget.y = 0;//pongo la "y" a 0 para que no se vuelque

        //transformo la direccion en una rotacion
        Quaternion rotacionATarget = Quaternion.LookRotation(direccionATarget);

        //aplicar la rotacion
        transform.rotation = rotacionATarget;
    }
    #region Ejecutados por evento de animacion

    private void InicioAnimacionataque()
    {
        ventanaAbierta = true;
    }
    private void Atacar()
    {
        // Verificar que el objetivo no sea nulo y tenga el componente IDanhable
        if (main.Target != null && main.Target.TryGetComponent(out IDanhable danhable))
        {
            // Aplicar daño al objetivo
            danhable.RecibirDanho(danhoAtaque);
            Debug.Log("Daño aplicado al objetivo: " + main.Target.name);
        }
        else
        {
            Debug.LogWarning("El objetivo no tiene el componente IDanhable o es nulo.");
        }

    }
    private void FinAnimacionAtaque()
    {
        anim.SetBool("attacking", false);
        agent.isStopped = false;
        ventanaAbierta = false;
    }

    private void DetectarImpacto()
    {
        //1º referenciar el attackPoint
        //2º crear una variable que represente el radio de ataque
        //3 crear una variable que represente que es dañable,(layer)


        Collider[] collDetectados = Physics.OverlapSphere(attackPoint.position, radioAtaque, queEsDanhable);

        //si hemos detectado algo dentro de nuestro radar
        if (collDetectados.Length > 0)
        {
            //pasoo collider por collider aplicando daño
            for (int i = 0; i < collDetectados.Length; i++)
            {
                collDetectados[i].GetComponent<Player>().RecibirDanho(danhoEnemigo);

            }
            puedoDanhar = false;
        }
    }

    public void RecibirDanho(float danho)
    {
        throw new NotImplementedException();
    }
    /*private void AbrirVentanaAtaque()
{
   ventanaAbierta = true;

}*/
    /*private void CerrarVentanaAtaque()
    {
        ventanaAbierta = false;

    }*/
    #endregion
}
