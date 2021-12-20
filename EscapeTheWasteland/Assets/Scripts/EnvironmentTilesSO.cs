using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewEnvironmentHolder", menuName = "ScriptableObjects/EnvironmentLayers")]

public class EnvironmentTilesSO : ScriptableObject
{
    [SerializeField]
    int[,] EnvironmentLocations;
    [SerializeField]
    GameObject _go;
}
