using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaMisiones : MonoBehaviour
{
    [SerializeField]
    private EventManagerSO eventManager;

    [SerializeField]
    private ToggleMision[] togglesMision; //coleccion de togles


    private void OnEnable()
    {
        //me suscribo al evento y lo vinculo con el metodo.
        eventManager.OnNuevaMision += EncenderToggleMision;
    }

    private void EncenderToggleMision(MisionSO mision)
    {
        /*togglesMision[].TextoMision.text = ¿?;
        togglesMision[?].ToggleVisual.isOn = false;*/
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
