using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetaDeMuerte : MonoBehaviour, IInteractuable
{
    private Outline outline;

    [SerializeField] private GameManagerSO gM;
    [SerializeField] private MisionSO mision;

    [SerializeField] private int identificador;

    [SerializeField] private EventManagerSO eventManager;

    private void Awake()
    {
        if (gM.dictionary.ContainsKey(identificador))
        {
            //consultar al gM si he de respauwnear o no
            if (!gM.dictionary[identificador] == false)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            gM.dictionary.Add(identificador, true);
        }
        outline = GetComponent<Outline> ();
        
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

        gM.dictionary[identificador] = false;
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
