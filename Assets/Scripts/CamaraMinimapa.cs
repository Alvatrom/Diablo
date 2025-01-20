using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMinimapa : MonoBehaviour
{
    [SerializeField]
    private Player player;

    private Vector3 distanciaAPlayer;
    // Start is called before the first frame update
    void Start()
    {
        distanciaAPlayer = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()// para evitar vibraciones de camara, espera que todos los elementos
        //se coloquen y luego pone la posicion en la camara, el lateUpdate es el ultimo de todos los update
    {
        transform.position = player.transform.position + distanciaAPlayer;
    }
}
