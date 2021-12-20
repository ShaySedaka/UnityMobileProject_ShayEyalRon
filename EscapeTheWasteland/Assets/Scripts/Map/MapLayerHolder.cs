using UnityEngine.Tilemaps;
using UnityEngine;

public class MapLayerHolder : MonoBehaviour
{
    [SerializeField]
    Tilemap _tileLayer;
    [SerializeField]
    TileBase _layerTile;
    [SerializeField]
    AreaHolder[] _areas;

}
