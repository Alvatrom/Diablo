using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class WallsDetector : MonoBehaviour
{
    [SerializeField] private float tiempoDifuminado;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstaculo"))
        {
            Material materialPared = other.GetComponent<MeshRenderer>().material;
            Color transparente = new Color(materialPared.color.r, materialPared.color.g, materialPared.color.b,0f);
            materialPared.DOColor(transparente, 1f);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Obstaculo"))
        {
            Material materialPared = other.GetComponent<MeshRenderer>().material;
            Color opaco = new Color(materialPared.color.r, materialPared.color.g, materialPared.color.b, 1f);
            materialPared.DOColor(opaco, 0f);
        }
    }
}
