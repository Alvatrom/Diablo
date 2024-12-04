using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour
{
    private Outline outline;
    [SerializeField] private Texture2D iconoPorDefecto;
    [SerializeField] private Texture2D iconoInteraccion;
    // Start is called before the first frame update
    void Start()
    {
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
}
