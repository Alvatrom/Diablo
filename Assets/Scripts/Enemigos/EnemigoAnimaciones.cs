using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoAnimaciones : MonoBehaviour
{
    [SerializeField] private Enemy main;
    [SerializeField] private NavMeshAgent agent;

    private Animator anim;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        main.VisualSystem = this;

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("velocity", agent.velocity.magnitude / agent.speed);
        
    }
    public void EjecutarAnimacionMuerte()
    {
        anim.SetBool("live", false);
    }

    public void StartAttacking()
    {
        anim.SetBool("attacking", true);
    }

    public void StopAttacking()
    {
        anim.SetBool("attacking", false);
    }
}
