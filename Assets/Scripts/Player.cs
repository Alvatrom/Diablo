using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private Camera cam;
    private NavMeshAgent agent;
    private NPC npc;
    private Transform ultimoClick;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 1)
        {
           Movimiento();

        }
        ComprobarInteraccion();
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
                ultimoClick = hitInfo.transform;
            }
        }
    }
    private void ComprobarInteraccion()
    {
        //si existe un interactuable al cual clike y lleva consigo el script NPC...
        if (ultimoClick != null && ultimoClick.TryGetComponent(out NPC npc))
        {
            //actualizo distancia de parada para no chocarse con npc
            agent.stoppingDistance = 2f;

            //mira a ver si hemos llegado a dicho destino
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                //y por lo tanto , interactuo con el NPC.
                //npc.Interactuar();

                //me olvido de cual fue el ultimo click, porque solo quiero interactuar una vez
                ultimoClick = null;
            }
            else if (ultimoClick)
            {
                //Reseteo el stoppingDistance original
                agent.stoppingDistance = 0f;
            }
        }
    }

}
