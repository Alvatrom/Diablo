using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerVisual : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //agent.velocity.magnitude ---> Velociddad actual....
        //agent.speed ---> Max velocidad que tengo configurada.
        animator.SetFloat("velocity", agent.velocity.magnitude / agent.speed);
        
    }
}
