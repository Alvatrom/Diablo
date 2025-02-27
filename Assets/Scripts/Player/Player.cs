using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour, IDanhable
{
    [SerializeField] private EventManagerSO eventManager;



    [SerializeField] private float vidas = 200;

    [SerializeField] private int oro = 0;

    [SerializeField] TMP_Text textoOro;
    [SerializeField] TMP_Text textoEXP;
    [SerializeField] TMP_Text textoVidas;
    [SerializeField] private float interactionDistance = 2f;
    [SerializeField] private float attackingDistance = 2f;
    [SerializeField] private float danhoAtaque = 10f;

    private int totalCoins;
    private NavMeshAgent agent;
    private Camera cam;
    //private NPC npc;//////////////////////////////////////es necesario?
    private Transform ultimoClick;

    private Transform currentTarget;
    private PlayerVisual visualSystem;

    public PlayerVisual VisualSystem { get => visualSystem; set => visualSystem = value; }
    public int TotalCoins { get => totalCoins; set => totalCoins = value; }

    public int Oro { get => oro; set => oro = value; }

    public TMP_Text TextoOro { get => textoOro; set => textoOro = value; }

    [SerializeField] private GameManagerSO gM;// para el sistema de guardado

    [SerializeField] private MisionSO interactuador;
    // Start is called before the first frame update


    void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        if (eventManager != null)
        {
            eventManager.OnTerminarMision += AgregarVelocidad;
        }
    }

    private void OnDisable()
    {
        if (eventManager != null)
        {
            eventManager.OnTerminarMision -= AgregarVelocidad;
        }
    }

    private void AgregarVelocidad(MisionSO mision)
    {
        agent.speed = 6;
        textoEXP.gameObject.SetActive(true);

        Debug.Log("Misión completada. Velocidad aumentada: ");   //Para hacer que las misiones den recompensa al momento

        // Llamar a la corrutina para desactivar el texto después de 4 segundos
        StartCoroutine(DesactivarTexto());

    }

    private IEnumerator DesactivarTexto()
    {
        yield return new WaitForSeconds(4f);

        textoEXP.gameObject.SetActive(false);
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
        if (ultimoClick != null && ultimoClick.TryGetComponent(out IInteractuable interactor))
        {
            //actualizo distancia de parada para no chocarse con npc
            agent.stoppingDistance = interactionDistance;

            //mira a ver si hemos llegado a dicho destino
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                interactor.Interactuar(transform);
                //me olvido de cual fue el ultimo click, porque solo quiero interactuar una vez
                ultimoClick = null;
            }
            else if (ultimoClick.TryGetComponent(out IDanhable _))//mirar si es dañable
            {
                currentTarget = ultimoClick;
                agent.stoppingDistance = attackingDistance;
                if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
                {
                    FaceTarget();
                    visualSystem.StartAttacking();
                }
            }
            else
            {
                agent.stoppingDistance = 0f;
            }
        }
    }

    private void FaceTarget()
    {
        Vector3 directionToTarget = (currentTarget.transform.position - transform.position).normalized;
        directionToTarget.y = 0f;
        Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget);
        transform.rotation = rotationToTarget;
    }

    public void Atacar()
    {
        currentTarget.GetComponent<IDanhable>().RecibirDanho(danhoAtaque);
    }

    public void RecibirDanho(float danho)
    {
        vidas -= danho;
        textoVidas.text = "Vida: " + vidas + "/ 200";
        //Vida: 100/100
        if (vidas <= 0)
        {
            Destroy(this);
            visualSystem.EjecutarAnimacionMuerte();
        }
    }
}
