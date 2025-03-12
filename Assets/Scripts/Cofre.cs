using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour, IInteractuable
{
    private Outline outline;
    [SerializeField] private Texture2D iconoPorDefecto;
    [SerializeField] private Texture2D iconoInteraccion;


    private Animator anim;
    public Player player;

    public bool abierto = false;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        outline = GetComponent<Outline>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        Cursor.SetCursor(iconoInteraccion, Vector2.zero,CursorMode.Auto);
        outline.enabled = true;
    }
    private void OnMouseExit()
    {
        Cursor.SetCursor(iconoPorDefecto, Vector2.zero,CursorMode.Auto);
        outline.enabled = false;
        
    }

    private void AbrirCofre()
    {
        anim.SetBool("Abierto", true);
        abierto = true;

    }

    public void Interactuar(Transform interactor)
    {

        //Player player = interactor.GetComponent<Player>();  // Obtener el componente Player
        if (player != null && abierto == false)
        {
            player.Oro += 50;  // Usamos la propiedad para modificar el oro
            player.TextoOro.text = "Gold " + player.Oro+ "/ 200";
            AudioManager.instance.PlaySFX("Gold");
            Debug.Log("50 de oro conseguido");
            AbrirCofre();
        }
        else
        {
            //Debug.LogError("No se encontró el componente Player en el interactor.");
            Debug.Log("No se encontró el componente Player en el interactor.");
        }
    }
}
