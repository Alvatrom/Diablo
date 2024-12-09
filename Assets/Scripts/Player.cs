using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private Camera cam;
    private NavMeshAgent agent;
    private Transform ultimoHit;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
    }

    private void Movimiento()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Creo un rayo desde la camara a la posicion del raton
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            //y si ese rayo impacta en algo...
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                // le decimos al agente que tiene como destino el punto de impacto
                agent.SetDestination(hitInfo.point);
                //actualizo el ultimoHit con el transform que acabo de clickar
                ultimoHit = hitInfo.transform;
            }
        }
    }
    private void ComprobarInteraccion()
    {
        /*if (ultimoClick != null)
        {

        }*/
    }

}
