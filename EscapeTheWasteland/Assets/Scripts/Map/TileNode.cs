using UnityEngine;
using UnityEngine.Tilemaps;

public class TileNode : MonoBehaviour
{
    TileNode(int xPos,int yPos,TileBase tile,Tilemap tileLayer)
    {
        _xPos = xPos;
        _yPos = yPos;
        _tile = tile;
        _tileLayer = tileLayer;
    }

    int _xPos;
    int _yPos;
    TileBase _tile;
    Tilemap _tileLayer;
}
//Tile node will hold it's position and it's UI elements that
