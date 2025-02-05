using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaCombate : MonoBehaviour
{
    [SerializeField] private Enemy main;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator anim;
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

        //solo si existe un objetivo y es alcanzable...
        if (main.Target != null && agent.CalculatePath(main.Target.position, new NavMeshPath()))
        {
            //procuramos que siempre estemos enfocando al player
            EnfocarObjetivo();
            //Perseguiremos al objetivo
            agent.SetDestination(main.Target.position);

            //CUando tenga al objetivo a distancia de ataque...
            if(!agent.pathPending && agent.remainingDistance >= distanciaAtaque)
            {

                anim.SetBool("attacking", true);
            }

        }
        else
        {
            anim.SetBool("attacking", false);
            //Deshabilitamos script de combate
            main.ActivarPatrulla();
        }
    }

    private void EnfocarObjetivo()
    {
        //1. calculo ña direccion al objetivo
        Vector3 direccionATarget =(main.Target.transform.position - transform.position).normalized;
        direccionATarget.y = 0;//pongo la "y" a 0 para que no se vuelque

        //transformo la direccion en una rotacion
        Quaternion rotacionATarget = Quaternion.LookRotation(direccionATarget);

        //aplicar la rotacion
        transform.rotation = rotacionATarget;
    }
    #region Ejecutados por evento de animacion
    private void Atacar()
    {
        //hacer daño al target
        main.Target.GetComponent<Player>().RecibirDanho(danhoAtaque);
    }
    private void FinAnimacionAtaque()
    {
        anim.SetBool("attacking", false);
    }
    #endregion
}
