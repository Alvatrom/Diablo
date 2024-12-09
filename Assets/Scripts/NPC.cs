using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private DialogoSO miDialogo;
    [SerializeField] private float duracionRotacion;

    
    public void Interactuar(Transform interactuador)
    {
        //poco a poco voy rotando hacia el interactuador y
        //Cuando termine de rotarme....se inicia la interacion
        //transform.DOLookAt(interactuador.position, duracionRotacion, AxisConstraint.Y).OnComplete(IniciarInteraccion);
    }

    private void IniciarInteracion()
    {
        //SistemaDialogo.sistema.IniciarDialogo(miDialogo);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
