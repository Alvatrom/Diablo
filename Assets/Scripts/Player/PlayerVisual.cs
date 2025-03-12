using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerVisual : MonoBehaviour
{
    [SerializeField] private GameManagerSO gM;
    [SerializeField] private int visualId;
    [SerializeField] private Player mainScript;
    [SerializeField] private NavMeshAgent agent;


    private Animator animator;

    private void Awake()
    {
        /*if (gM.IdCharacterSelected == visualId) ///////////////////////////////////preguntar el id
        {
            animator = GetComponent<Animator>();
            mainScript.VisualSystem = this;
        }
        else
        {
            Destroy(gameObject);
        }*/
        animator = GetComponent<Animator>();
        mainScript.VisualSystem = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //agent.velocity.magnitude ---> Velociddad actual....
        //agent.speed ---> Max velocidad que tengo configurada.
        animator.SetFloat("velocity", agent.velocity.magnitude / agent.speed);
        
    }

    private void LanzarAtaque()
    {
        mainScript.Atacar();
    }

    public void EjecutarAnimacionMuerte()
    {
        animator.SetBool("live", false);
    }

    public void StartAttacking()
    {
        animator.SetBool("attacking", true);
    }

    public void StopAttacking()
    {
        animator.SetBool("attacking", false);
    }

    public void ReproducirSonidoAtaque()
    {
        AudioManager.instance.PlaySFX("HurtPlayer");
    }
}
