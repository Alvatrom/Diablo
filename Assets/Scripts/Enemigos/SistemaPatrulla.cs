
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Jobs;

public class SistemaPatrulla : MonoBehaviour
{
    [SerializeField] private Enemy main;

    [SerializeField] private Transform ruta;

    [SerializeField] private NavMeshAgent agent;

    [SerializeField] float velocidadPatrulla;

    private List<Vector3> listadoPuntos = new List<Vector3>();

    private int indiceDestinoActual = -1;//marca el punto al cual debo ir 

    private Vector3 destinoActual;

    private void Awake()
    {
        //le digo al "main" (enemigo) que el sistema de patrulla que tiene soy yo
        main.Patrulla = this;
        foreach (Transform t in ruta)
        {
            //añado todos los puntos de ruta al listado
            listadoPuntos.Add(t.position);
        }
    }
    private void OnEnable()
    {
        //el stoppingDistance vuelve a ser 0
        agent.stoppingDistance = 0;
        agent.speed = velocidadPatrulla;//vuelvo a la velocidad de patrulla
        StartCoroutine(PatrullarYEsperar());
    }


    // Start is called before the first frame update
    void Start()
    {
    }
    private IEnumerator PatrullarYEsperar() 
    {
        while (true)
        {
            CalcularDestino();// tendre que calcular el nuevo destino
            agent.SetDestination(destinoActual);
            yield return new WaitUntil(() => agent.remainingDistance <= 0);//expresion Lambda (anonimo), si cumple con la distancia es == true

            yield return new WaitForSeconds(Random.Range(0.25f, 3f));
        }
    }

    private void CalcularDestino()
    {
        indiceDestinoActual++;

        //si nos hemos quedado sin puntos...
        if(indiceDestinoActual >= listadoPuntos.Count)
        {
            indiceDestinoActual = 0;
        }

        //mi destino es dentro del listado de puntos aquel con el nuevo indice calculado.
        destinoActual = listadoPuntos[indiceDestinoActual];
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopAllCoroutines();//abandonamos la corrutina de patrulla

            //le digo a "main" que active el combate,pasandole el objetivo al que tiene que perseguir
            main.ActivarCombate(other.transform);
            
        }
    }
}
