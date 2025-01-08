
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Jobs;

public class SistemaPatrulla : MonoBehaviour
{
    [SerializeField] private Transform ruta;

    [SerializeField] private NavMeshAgent agent;

    private List<Vector3> listadoPuntos = new List<Vector3>();

    private int indiceActual = 0; //marca el punto al cual debo ir


    private Vector3 destinoActual;



    private void Awake()
    {
        foreach (Transform t in ruta)
        {
            //añado todos los puntos de ruta al listado
            listadoPuntos.Add(t.position);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PatrullarYEsperar());
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
        indiceActual++;

        //si nos hemos quedado sin puntos...
        if(indiceActual >= listadoPuntos.Count)
        {
            indiceActual = 0;
        }

        //mi destino es dentro del listado de puntos aquel con el nuevo indice calculado.
        destinoActual = listadoPuntos[indiceActual];
        
    }
}
