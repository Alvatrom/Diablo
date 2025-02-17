using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SistemaDialogo : MonoBehaviour
{

    public static SistemaDialogo sistema;

    [SerializeField] private EventManagerSO eventManager;

    //cuando es estatica;esa variable pertenece a la clase(no a las instamcias de la clase)(un unico trono)

    [SerializeField] private GameObject marcoDialogo;//marco a habilitar/deshabilitar

    [SerializeField] private TMP_Text textoDialogo;// el texto donde se veran reflejados los dialogos
    
    [SerializeField] private Transform npcCamera;// Camara compartida por todos los NPC


    [SerializeField] private AudioSource audioSource; ////para poner audio de ias //////////////////////////////////////////////////////

    private bool escribiendo;
    private int indiceFraseActual = 0;

    private DialogoSO dialogoActual;// para saber en todo momento cual es el dialogo con el que estamos trabajando

    [SerializeField] DialogoSO recompensaDialogo2;
    public bool recompensaRecogida = false;
    [SerializeField] Player player;


    //Awake se ejecuta antes del start() independientemente de que 
    //el gameobject este activa o no
    void Awake()
    {
        //Si el trono esta libre...
        if (sistema == null)
        {
            //me hago con el trono, y entonces SistemaDialogo SOY YO (this).
            sistema = this;
        }
        else
        {
            //esta ocupado pues me suicido
          Destroy(this.gameObject);

        }
    }

    public void IniciarDialogo(DialogoSO dialogo, Transform cameraPoint)
    {
        Time.timeScale = 0;


        //el dialogo actual que tenemos que tratar es el que me pasan por paraametro
        dialogoActual = dialogo;
        marcoDialogo.SetActive(true);
       


        //posiciono la camera en el punto de este NPC

        npcCamera.SetPositionAndRotation(cameraPoint.position, cameraPoint.rotation);
        //esto es lo mismo que la linea anterior
        /*npcCamera.position = cameraPoint.position;
        npcCamera.rotation = cameraPoint.rotation;*/


        StartCoroutine(EscribirFrase());

    }
    //Sirve para escribir frase letra por letra
    private IEnumerator EscribirFrase()
    {
        escribiendo = true;

        audioSource.clip = dialogoActual.frasesClips[indiceFraseActual];
        audioSource.Play();

        //Limpio el texto
        textoDialogo.text = string.Empty;
        //Desmenuza la frase por caracteres por separado.
        char[] fraseEnLetras = dialogoActual.frases[indiceFraseActual].ToCharArray();

        foreach (char letra in fraseEnLetras)
        {
            //1. incluir la letra en el texto
            textoDialogo.text += letra;

            //WaitForSecondsRealtime: no se para si el tiempo esta congelado
            yield return new WaitForSecondsRealtime(dialogoActual.tiempoEntreLetras);
        }

        escribiendo = false;
    }


    // sirve para autocompletar la frase
    private void CompletarFrase()
    {
        //si me piden completar la frase entera, en el texto pongo la frase entera.
        textoDialogo.text = dialogoActual.frases[indiceFraseActual];
        //paro las corrutinas que puedan estar vivas(para que no siga la rutina poniendo el texto)
        StopAllCoroutines();

        escribiendo = false;
    }


    //se ejecuta al hacer click al boton para pasar a la siguiente frase 
    public void SiguienteFrase()
    {
        if (!escribiendo)
        {
            indiceFraseActual++;//Avanzo a la siguiente frase

            //si aun me quedan frases por sacar...
            if (indiceFraseActual < dialogoActual.frases.Length)
            {
                //La escribo
                StartCoroutine(EscribirFrase());
            }
            else
            {
                FinalizarDialogo();
            }
        }
        else
        {
            CompletarFrase();
        }
    }
    private void FinalizarDialogo()
    {
        Time.timeScale = 1.0f;
        marcoDialogo.SetActive(false); //cerramos el marco de dialogo
        indiceFraseActual = 0; // para que en posteriores dialogo empezamos desde indice 0.
        StopAllCoroutines();
        
        if(dialogoActual == recompensaDialogo2)
        {
            RecogerRecompensa();
        }

        if (dialogoActual.tieneMision)
        {
            eventManager.NuevaMision(dialogoActual.mision);
        }
        dialogoActual = null;// Ya no tengo dialogo que escribir
    }

    private void Recompensa()
    {
        recompensaRecogida = true;

    }

    public void RecogerRecompensa()
    {

        //Player player = interactor.GetComponent<Player>();  // Obtener el componente Player
        if (player != null && recompensaRecogida == false)
        {
            player.Oro += 50;  // Usamos la propiedad para modificar el oro
            player.TextoOro.text = "Gold " + player.Oro + "/ 200";
            Debug.Log("50 de oro conseguido");
            Recompensa();
        }
        else
        {
            Debug.LogError("No se encontró el componente Player en el interactor.");
        }
    }

}
