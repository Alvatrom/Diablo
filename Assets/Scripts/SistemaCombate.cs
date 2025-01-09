using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaCombate : MonoBehaviour
{
    [SerializeField] private Enemy main;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] float velocidadCombate = 8f;


    private void Awake()
    {
        main.Combate = this;
    }

    private void OnEnable()
    {
        agent.speed = velocidadCombate;

    }
    private void Update()
    {
        //voy persiguiendo al target en todo momento (calculando su posicion)
        agent.SetDestination(main.Target.position);
    }
}
