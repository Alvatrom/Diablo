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
        eventManager.OnActualizarMision += ActualizarToggleMision;
        eventManager.OnTerminarMision += TerminarToggleMision;
    }

    

    private void EncenderToggleMision(MisionSO mision)
    {
        //alineamos el texto con el contenido de la mision
        togglesMision[mision.indiceMision].TextoMision.text = mision.ordenInicial;

        //Y si tiene repeticion...
        if (mision.tieneRepeticion)
        {
           togglesMision[mision.indiceMision].TextoMision.text += "(" + mision.repeticionActual + "/" + mision.totalRepeticiones + ")";

        }

        togglesMision[mision.indiceMision].gameObject.SetActive(true);

        //togglesMision[?].ToggleVisual.isOn = false;*/
    }
    private void ActualizarToggleMision(MisionSO mision)
    {
        togglesMision[mision.indiceMision].TextoMision.text = mision.ordenInicial;
        togglesMision[mision.indiceMision].TextoMision.text += "(" + mision.repeticionActual + "/" + mision.totalRepeticiones + ")";
    }
    private void TerminarToggleMision(MisionSO mision)
    {
        //togglesMision[mision.indiceMision].ToggleVisual.isOn = true;//al terminar la mision "chekeamos" el toggle
        togglesMision[mision.indiceMision].TextoMision.text = mision.ordenFinal; // ponemos el texto de victoria

    }

}
