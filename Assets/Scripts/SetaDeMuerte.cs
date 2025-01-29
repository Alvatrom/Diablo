using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetaDeMuerte : MonoBehaviour, IInteractuable
{
    private Outline outline;

    [SerializeField] private MisionSO mision;

    [SerializeField] private EventManagerSO eventManager;

    private void Awake()
    {
        outline = GetComponent<Outline>();
    }

    private void OnMouseEnter()
    {
        outline.enabled = true;
    }
    private void OnMouseExit()
    {
        outline.enabled = false;
    }
    public void Interactuar(Transform interactor)
    {
        mision.repeticionActual++; // aumentamos en uno la repeticion de esta mision

        //Todavia quedan setas por recoger 
        if(mision.repeticionActual< mision.totalRepeticiones)
        {
            eventManager.ActualizarMision(mision);
        }
        else // ya hemos terminado de recoger todas las setas
        {
            eventManager.TerminarMision(mision);
        }
        Destroy(gameObject);
    }
}
