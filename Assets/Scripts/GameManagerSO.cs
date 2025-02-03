using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameManager")]

public class GameManagerSO : MonoBehaviour
{
    public int lifes;
    public Vector3 ultimaPosicion;
    public Dictionary<int,bool> dictionary = new Dictionary<int,bool>();
}
